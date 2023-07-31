using MediatR;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Application.ParkingHistorys;
public record ParkingHistoryInputCreateCommand(Guid cellId, string licensePlate, Guid typeVehicleId, int cylinderCapacity) : IRequest<ParkingHistoryDto>;
public record ParkingHistoryOutputUpdateCommand(Guid id) : IRequest<ParkingHistoryDto>;


