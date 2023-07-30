using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Ports;
using ParkingLots.Infrastructure.Ports;

namespace ParkingLots.Infrastructure.Adapters;

[Repository]
public class TypeVehicleRepository : ITypeVehiclesRepository
{
    readonly IRepository<TypeVehicle> _dataSource;
    private readonly IUnitOfWork _unitOfWork;

    public TypeVehicleRepository(IRepository<TypeVehicle> dataSource, IUnitOfWork unitOfWork)
    {
        _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TypeVehicle>> GetAllTypeVehicle()
    {
        return await _dataSource.GetManyAsync();
    }

    public async Task<TypeVehicle> GetByIdTypeVehicle(Guid id)
    {
        var cell = await _dataSource.GetOneAsync(id);
        return cell;
    }

    public async Task<TypeVehicle> SaveTypeVehicle(TypeVehicle typeVehicle)
    {
        var typeVehicles = await _dataSource.AddAsync(typeVehicle);
        await _unitOfWork.SaveAsync();
        return typeVehicles;
    }

    public async Task<bool> UpdateTypeVehicle(TypeVehicle typeVehicle)
    {
        return await _dataSource.UpdateConfirmationAsync(typeVehicle);
    }

    public async Task<bool> DeleteTypeVehicle(TypeVehicle typeVehicle)
    {
        return await _dataSource.DeleteConfirmationAsync(typeVehicle);
    }

}
