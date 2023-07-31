namespace ParkingLots.Domain.Dtos;

public record CellsDto(Guid id, string cellNumber, Guid typeVehicleId, bool cellBusy);
