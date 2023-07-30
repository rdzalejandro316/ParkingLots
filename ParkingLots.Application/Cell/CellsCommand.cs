using MediatR;
using ParkingLots.Domain.Dto;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Application.Cell;
public record CellsCreateCommand(string cellNumber, int typeVehicleId, bool cellBusy) : IRequest<CellsDto>;
public record CellsUpdateCommand(Guid id, string cellNumber, int typeVehicleId, bool cellBusy) : IRequest<bool>;
