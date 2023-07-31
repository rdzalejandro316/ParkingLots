using AutoMapper;
using MediatR;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Ports;

namespace ParkingLots.Application.Cell;
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

        Cells cells = _mapper.Map<Cells>(request);
        var cell = await _repository.SaveCell(cells);
        return _mapper.Map<CellsDto>(cell);
    }

}

public class CellCommandUpdateHandler : IRequestHandler<CellsUpdateCommand, bool>
{
    private readonly ICellsRepository _repository;
    private readonly IMapper _mapper;

    public CellCommandUpdateHandler(ICellsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CellsUpdateCommand request, CancellationToken cancellationToken)
    {
        Cells cells = _mapper.Map<Cells>(request);
        var succes = await _repository.UpdateCell(cells);
        return succes;
    }

}