using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Ports;
using ParkingLots.Infrastructure.Ports;
using System.Data.Common;

namespace ParkingLots.Infrastructure.Adapters;

[Repository]
public class ParkingHistoryRepository : IParkingHistoryRepository
{
    readonly IRepository<ParkingHistory> _dataSource;
    private readonly IUnitOfWork _unitOfWork;

    public ParkingHistoryRepository(IRepository<ParkingHistory> dataSource, IUnitOfWork unitOfWork)
    {
        _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<ParkingHistory>> GetAllParkingHistory()
    {
        return await _dataSource.GetManyAsync();
    }

    public async Task<ParkingHistory> GetByIdParkingHistory(Guid id)
    {
        return await _dataSource.GetOneAsync(id);
    }

    public async Task<ParkingHistory> SaveParkingHistory(ParkingHistory parkingHistory)
    {
        var _parkingHistory = await _dataSource.AddAsync(parkingHistory);
        await _unitOfWork.SaveAsync();
        return _parkingHistory;
    }

    public async Task<bool> UpdateParkingHistory(ParkingHistory parkingHistory)
    {
        return await _dataSource.UpdateConfirmationAsync(parkingHistory);
    }

    public async Task<bool> DeleteParkingHistory(ParkingHistory parkingHistory)
    {
        return await _dataSource.DeleteConfirmationAsync(parkingHistory);
    }
}
