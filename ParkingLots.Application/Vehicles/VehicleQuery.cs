using MediatR;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Application.Vehicles;
public record VehicleGetById(Guid id) : IRequest<VehicleDto>;
public record VehicleGetAll() : IRequest<IEnumerable<VehicleDto>>;