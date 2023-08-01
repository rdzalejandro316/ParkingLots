namespace ParkingLots.Domain.Dtos;

public record TypeVehicleDto(Guid id, string nameTypeVehicle,decimal valueHour, decimal valueDay,bool restriction);

