namespace ParkingLots.Domain.Dtos;
public record ParkingHistoryDto(Guid id, Guid cellId, Guid typeVehicleId, DateTime startDate, DateTime endingDate);
public record ParkingHistoryInputDto(Guid cellId, string licensePlate, Guid typeVehicleId, int cylinderCapacity);
