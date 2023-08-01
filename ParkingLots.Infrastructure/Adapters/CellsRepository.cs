using Microsoft.EntityFrameworkCore;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Ports;
using ParkingLots.Infrastructure.Ports;
using System.Data.Common;
using System.IO;

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
        var cell = await _dataSource.GetOneAsync(id);
        return cell;
    }

    public async Task<Cells> GetByIdCellAndTypeVehicle(Guid id)
    {
        Cells cell = await _dataSource.GetByIdWithIncludesAsync(c => c.Id == id, t => t.TypeVehicle);
        return cell;
    }

    public async Task<Cells> SaveCell(Cells cells)
    {
        var cell = await _dataSource.AddAsync(cells);
        await _unitOfWork.SaveAsync();
        return cell;
    }

    public async Task<bool> UpdateCell(Cells cell)
    {
        return await _dataSource.UpdateConfirmationAsync(cell);
    }

    public async Task<bool> UpdateBusyCell(Guid id, bool cellBusy)
    {
        Cells cell = await GetByIdCell(id);
        cell.CellBusy = cellBusy;
        return await UpdateCell(cell);
    }

    public async Task<bool> DeleteCell(Cells cells)
    {
        return await _dataSource.DeleteConfirmationAsync(cells);
    }
}
