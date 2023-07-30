using AutoMapper;
using MediatR;
using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Ports;

namespace ParkingLots.Application.Cells;
public class CellCommandCreateHandler : IRequestHandler<CellsCreateCommand, CellsDto>
{
    private readonly ICellsRepository _repository;
    private readonly IMapper _mapper;

    public CellCommandCreateHandler(ICellsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<CellsDto> Handle(CellsCreateCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Cells cells = new Domain.Entities.Cells {
            CellNumber = request.cellNumber,
            TypeVehicleId = request.typeVehicleId,
            CellBusy= request.cellBusy
        };

        var cell = await _repository.SaveCell(cells);
        //return new CellsDto(cells.Id, cells.CellNumber, cells.TypeVehicleId, cells.CellBusy);
        return _mapper.Map<CellsDto>(cell);        
    }

}

public class CellCommandUpdateHandler : IRequestHandler<CellsUpdateCommand, CellsDto>
{
    private readonly ICellsRepository _repository;
    private readonly IMapper _mapper;

    public CellCommandUpdateHandler(ICellsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<CellsDto> Handle(CellsUpdateCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Cells cells = _mapper.Map<Domain.Entities.Cells>(request);
        var cell = await _repository.UpdateCell(cells);
        return _mapper.Map<CellsDto>(cell);
    }

}