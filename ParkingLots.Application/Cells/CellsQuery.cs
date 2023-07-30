using MediatR;
using ParkingLots.Domain.Dto;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Application.Cells;

public record CellsGetById(Guid id) : IRequest<CellsDto>;
public record CellGetAll() : IRequest<IEnumerable<CellsDto>>;

