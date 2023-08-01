using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Ports;
using ParkingLots.Infrastructure.Ports;

namespace ParkingLots.Infrastructure.Adapters;

[Repository]
public class VehiclesRepository : IVehiclesRepository
{
    readonly IRepository<Vehicle> _dataSource;
    private readonly IUnitOfWork _unitOfWork;

    public VehiclesRepository(IRepository<Vehicle> dataSource, IUnitOfWork unitOfWork)
    {
        _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Vehicle>> GetAllVehicle()
    {
        return await _dataSource.GetManyAsync();
    }

    public async Task<Vehicle> GetByIdVehicle(Guid id)
    {
        var cell = await _dataSource.GetOneAsync(id);
        return cell;
    }

    public async Task<Vehicle> GetByLicensePlateVehicle(string licensePlate)
    {
        return await _dataSource.FirstOrDefaultAsync(c => c.LicensePlate == licensePlate);
    }

    public async Task<Vehicle> SaveVehicle(Vehicle vehicles)
    {
        var vehicle = await _dataSource.AddAsync(vehicles);
        await _unitOfWork.SaveAsync();
        return vehicle;
    }

    public async Task<bool> UpdateVehicle(Vehicle vehicles)
    {
        return await _dataSource.UpdateConfirmationAsync(vehicles);
    }

    public async Task<bool> DeleteVehicle(Vehicle vehicles)
    {
        return await _dataSource.DeleteConfirmationAsync(vehicles);
    }    
}
