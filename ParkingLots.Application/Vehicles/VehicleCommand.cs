using MediatR;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Application.Vehicles;
public record VehicleCreateCommand(string licensePlate, Guid typeVehicleId, int cylinderCapacity) : IRequest<VehicleDto>;
public record VehicleUpdateCommand(Guid id, string licensePlate, Guid typeVehicleId, int cylinderCapacity) : IRequest<bool>;
