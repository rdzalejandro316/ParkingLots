namespace ParkingLots.Domain.Dtos;

public record CellsDto(Guid id, string cellNumber, int typeVehicleId, bool cellBusy);
