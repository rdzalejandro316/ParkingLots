using MediatR;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Application.ParkingHistorys;

public record ParkingHistoryGetById(Guid id) : IRequest<ParkingHistoryDto>;
public record ParkingHistoryGetAll() : IRequest<IEnumerable<ParkingHistoryDto>>;
