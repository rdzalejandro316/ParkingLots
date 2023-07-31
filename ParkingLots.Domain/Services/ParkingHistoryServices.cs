using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Exceptions;
using ParkingLots.Domain.Ports;
using ParkingLots.Domain.Constants;

namespace ParkingLots.Domain.Services;

[DomainService]
public class ParkingHistoryServices
{
    private readonly IParkingHistoryRepository _parkingHistoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ParkingHistoryServices(IParkingHistoryRepository parkingHistoryRepository, IUnitOfWork unitOfWork)
    {
        _parkingHistoryRepository = parkingHistoryRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task RecordParkingHistoryAsync(ParkingHistoryInputDto parkingHistoryInput)
    {
        CheckPicoPlaca(parkingHistoryInput.licensePlate);


    }

    void CheckPicoPlaca(string licensePlate)
    {
        char finishedPlate = licensePlate[licensePlate.Length - 1];
        int getLastNumberPlate = (int)Char.GetNumericValue(finishedPlate);
        int day = DateTime.Now.Day;

        if ((day % 2) == 0)
        {
            //Es un número par  1, 2, 3, 4 y 5
            bool oddDay = Enum.IsDefined(typeof(PicoPlaca.OddDay), getLastNumberPlate);
            if (!oddDay) throw new PicoPlacaException($"el vehiculo con placas {licensePlate} se encuentra en pico y placa");           
        }
        else
        {
            //Es un número impar  6, 7, 8, 9 y 0.
            bool evenDay = Enum.IsDefined(typeof(PicoPlaca.EvenDay), getLastNumberPlate);
            if (!evenDay) throw new PicoPlacaException($"el vehiculo con placas {licensePlate} se encuentra en pico y placa");
        }                
    }



}
