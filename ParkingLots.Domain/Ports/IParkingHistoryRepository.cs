using ParkingLots.Domain.Entities;

namespace ParkingLots.Domain.Ports;

public interface IParkingHistoryRepository
{
    Task<IEnumerable<ParkingHistory>> GetAllParkingHistory();
    Task<ParkingHistory> GetByIdParkingHistory(Guid id);
    Task<ParkingHistory> SaveParkingHistory(ParkingHistory parkingHistory);
    Task<bool> UpdateParkingHistory(ParkingHistory parkingHistory);
    Task<bool> DeleteParkingHistory(ParkingHistory parkingHistory);
}
