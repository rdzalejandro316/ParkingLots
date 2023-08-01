using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Exceptions;
using ParkingLots.Domain.Ports;
using ParkingLots.Domain.Constants;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Domain.Services;

[DomainService]
public class ParkingHistoryServices
{
    private readonly IParkingHistoryRepository _parkingHistoryRepository;
    private readonly IVehiclesRepository _vehicleRepository;
    private readonly ICellsRepository _cellsRepository;
    private readonly ITypeVehiclesRepository _typeVehicleRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ParkingHistoryServices(
        IParkingHistoryRepository parkingHistoryRepository,
        IVehiclesRepository vehiclesRepository,
        ICellsRepository cellsRepository,
        ITypeVehiclesRepository typeVehicleRepository,
        IUnitOfWork unitOfWork)
    {
        _parkingHistoryRepository = parkingHistoryRepository;
        _vehicleRepository = vehiclesRepository;
        _cellsRepository = cellsRepository;
        _typeVehicleRepository = typeVehicleRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ParkingHistory> RecordInPutParkingHistoryAsync(ParkingHistoryInputDto parkingHistoryInput)
    {
        TypeVehicle typeVehicle = await _typeVehicleRepository.GetByIdTypeVehicle(parkingHistoryInput.typeVehicleId);
        if (typeVehicle.Restriction) CheckPicoPlaca(parkingHistoryInput.licensePlate); // valida si es un vehiculo con pico y placa 

        Vehicle vehicleRegistered = await _vehicleRepository.GetByLicensePlateVehicle(parkingHistoryInput.licensePlate);

        if (vehicleRegistered == null)
        {
            Vehicle vehicle = new Vehicle
            {
                LicensePlate = parkingHistoryInput.licensePlate,
                TypeVehicleId = parkingHistoryInput.typeVehicleId,
                CylinderCapacity = parkingHistoryInput.cylinderCapacity
            };

            vehicleRegistered = await _vehicleRepository.SaveVehicle(vehicle);
        }


        ParkingHistory parkingHistory = new ParkingHistory
        {
            CellId = parkingHistoryInput.cellId,
            VehicleId = vehicleRegistered.Id,
            StartDate = DateTime.Now,
            EndingDate = null,
            ValueParking= 0
        };

        await _cellsRepository.UpdateBusyCell(parkingHistoryInput.cellId, true);
        ParkingHistory parking = await _parkingHistoryRepository.SaveParkingHistory(parkingHistory);
        return parking;
    }

    void CheckPicoPlaca(string licensePlate)
    {
        char finishedPlate = licensePlate[licensePlate.Length - 1];
        int getLastNumberPlate = (int)Char.GetNumericValue(finishedPlate);
        int day = DateTime.Now.Day;

        if ((day % 2) == 0)//par
        {
            //placas que no pueden circular 1, 2, 3, 4 y 5
            bool oddDay = Enum.IsDefined(typeof(PicoPlaca.OddDay), getLastNumberPlate);
            if (!oddDay) throw new PicoPlacaException($"el vehiculo con placas {licensePlate} se encuentra en pico y placa");
        }
        else //impar 
        {
            //placas que no pueden circular 6, 7, 8, 9 y 0.
            bool evenDay = Enum.IsDefined(typeof(PicoPlaca.EvenDay), getLastNumberPlate);
            if (!evenDay) throw new PicoPlacaException($"el vehiculo con placas {licensePlate} se encuentra en pico y placa");
        }
    }

    public async Task<ParkingHistory> RecordOutPutParkingHistoryAsync(ParkingHistoryOutPutDto parkingHistoryOutPutDto)
    {
        ParkingHistory parking = await _parkingHistoryRepository.GetByIdParkingHistory(parkingHistoryOutPutDto.idParkingHistory);
        parking.EndingDate = DateTime.Now;
        Cells cell = await _cellsRepository.GetByIdCellAndTypeVehicle(parking.CellId);

        DateTime fecIni = parking.StartDate;
        DateTime fecFin = DateTime.Now;
        TimeSpan ts = fecFin - fecIni;

        decimal valor = ts.Days * cell.TypeVehicle.ValueDay;
        if (ts.Hours > 0) valor += ts.Hours * cell.TypeVehicle.ValueHour;
        if (ts.Days == 0 && ts.Hours == 0) valor += cell.TypeVehicle.ValueHour;// es por que no lleba la hora completa
        parking.ValueParking = valor;

        await _parkingHistoryRepository.UpdateParkingHistory(parking);
        await _cellsRepository.UpdateBusyCell(parking.CellId, false);
        return parking;
    }


}
