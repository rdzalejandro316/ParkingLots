using MediatR;
using ParkingLots.Domain.Dto;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Application.Cells;
public record CellsCreateCommand(string cellNumber, int typeVehicleId, bool cellBusy) : IRequest<CellsDto>;
public record CellsUpdateCommand(Guid id, bool cellBusy) : IRequest<CellsDto>;
