using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Ports;
using ParkingLots.Infrastructure.Ports;
using System.Data.Common;

namespace ParkingLots.Infrastructure.Adapters;

[Repository]
public class CellsRepository : ICellsRepository
{
    readonly IRepository<Cells> _dataSource;
    private readonly IUnitOfWork _unitOfWork;

    public CellsRepository(IRepository<Cells> dataSource, IUnitOfWork unitOfWork)
    {
        _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Cells>> GetAllCell()
    {
        return await _dataSource.GetManyAsync();
    }

    public async Task<Cells> GetByIdCell(Guid id)
    {
        return await _dataSource.GetOneAsync(id);
    }

    public async Task<Cells> SaveCell(Cells cells)
    {
        var cell = await _dataSource.AddAsync(cells);        
        await _unitOfWork.SaveAsync();
        return cell;
    }

    public async Task<bool> UpdateCell(Cells cells)
    {
        return await _dataSource.UpdateConfirmationAsync(cells);
    }

    public async Task<bool> DeleteCell(Cells cells)
    {
        return await _dataSource.DeleteConfirmationAsync(cells);
    }
}
