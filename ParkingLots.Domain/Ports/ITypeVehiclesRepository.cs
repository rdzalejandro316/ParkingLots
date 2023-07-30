using ParkingLots.Domain.Entities;

namespace ParkingLots.Domain.Ports;
public interface ITypeVehiclesRepository
{
    Task<IEnumerable<TypeVehicle>> GetAllTypeVehicle();
    Task<TypeVehicle> GetByIdTypeVehicle(Guid id);
    Task<TypeVehicle> SaveTypeVehicle(TypeVehicle typeVehicle);
    Task<bool> UpdateTypeVehicle(TypeVehicle typeVehicle);
    Task<bool> DeleteTypeVehicle(TypeVehicle typeVehicle);
}
