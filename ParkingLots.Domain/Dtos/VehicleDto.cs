namespace ParkingLots.Domain.Dtos;
public record VehicleDto(Guid id, string licensePlate, Guid typeVehicleId, int cylinderCapacity);
public record VehicleInputDto(string licensePlate, Guid typeVehicleId, int cylinderCapacity);

