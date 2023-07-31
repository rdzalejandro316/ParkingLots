using ParkingLots.Domain.Entities;

namespace ParkingLots.Domain.Ports;
public interface IVehiclesRepository
{
    Task<IEnumerable<Vehicle>> GetAllVehicle();
    Task<Vehicle> GetByIdVehicle(Guid id);
    Task<Vehicle> SaveVehicle(Vehicle vehicle);
    Task<bool> UpdateVehicle(Vehicle vehicle);
    Task<bool> DeleteVehicle(Vehicle vehicle);
}

