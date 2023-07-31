using MediatR;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Application.Vehicles;
public record VehicleCreateCommand(string licensePlate, int typeVehicleId, int cylinderCapacity) : IRequest<VehicleDto>;
public record VehicleUpdateCommand(Guid id, string licensePlate, string typeVehicleId, int cylinderCapacity) : IRequest<bool>;
