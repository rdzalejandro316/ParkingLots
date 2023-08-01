namespace ParkingLots.Domain.Dtos;
public record ParkingHistoryDto(Guid id, Guid cellId, Guid vehicleId, DateTime startDate, DateTime? endingDate, decimal valueParking);
public record ParkingHistoryInputDto(Guid cellId, string licensePlate, Guid typeVehicleId, int cylinderCapacity);
public record ParkingHistoryOutPutDto(Guid idParkingHistory);
