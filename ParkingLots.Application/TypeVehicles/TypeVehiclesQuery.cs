
using MediatR;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Application.TypeVehicles;

public record TypeVehiclesGetById(Guid id) : IRequest<TypeVehicleDto>;
public record TypeVehiclesGetAll() : IRequest<IEnumerable<TypeVehicleDto>>;
