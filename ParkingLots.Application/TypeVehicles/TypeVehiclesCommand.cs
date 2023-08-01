using MediatR;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Application.TypeVehicles;
public record TypeVehiclesCreateCommand(string nameTypeVehicle, decimal valueHour, decimal valueDay, bool restriction) : IRequest<TypeVehicleDto>;
public record TypeVehiclesUpdateCommand(Guid id, string nameTypeVehicle, decimal valueHour, decimal valueDay, bool restriction) : IRequest<bool>;