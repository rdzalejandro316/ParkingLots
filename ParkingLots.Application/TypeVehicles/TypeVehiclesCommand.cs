using MediatR;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Application.TypeVehicles;
public record TypeVehiclesCreateCommand(string nameTypeVehicle) : IRequest<TypeVehicleDto>;
public record TypeVehiclesUpdateCommand(Guid id, string nameTypeVehicle) : IRequest<bool>;

