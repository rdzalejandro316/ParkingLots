using MediatR;
using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Application.ParkingHistorys;
public record ParkingHistoryInputCreateCommand(Guid cellId, string licensePlate, Guid typeVehicleId, int cylinderCapacity) : IRequest<ParkingHistoryDto>;
public record ParkingHistoryOutputUpdateCommand(Guid idParkingHistory) : IRequest<ParkingHistoryDto>;


