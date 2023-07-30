using ParkingLots.Domain.Entities;

namespace ParkingLots.Domain.Ports;

public interface interfaceIParkingHistory
{
    Task<IEnumerable<ParkingHistory>> GetAllParkingHistory();
    Task<ParkingHistory> GetByIdParkingHistory(int parkingHistoryId);
    Task<ParkingHistory> SaveInputParkingHistory(int parkingHistoryId);
    Task<ParkingHistory> SaveOuputParkingHistory(int parkingHistoryId);
}

