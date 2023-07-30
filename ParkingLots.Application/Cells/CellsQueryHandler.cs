using AutoMapper;
using MediatR;
using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Ports;

namespace ParkingLots.Application.Cells;

public class CellsQueryGetAllHandler : IRequestHandler<CellGetAll, IEnumerable<CellsDto>>
{
    private readonly ICellsRepository _repository;
    private readonly IMapper _mapper;
    public CellsQueryGetAllHandler(ICellsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CellsDto>> Handle(CellGetAll request, CancellationToken cancellationToken)
    {
        var cell = await _repository.GetAllCell();
        return _mapper.Map<IEnumerable<CellsDto>>(cell);
    }
}



public class CellsQueryGetByIdHandler : IRequestHandler<CellsGetById, CellsDto>
{
    private readonly ICellsRepository _repository;
    private readonly IMapper _mapper;
    public CellsQueryGetByIdHandler(ICellsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CellsDto> Handle(CellsGetById request, CancellationToken cancellationToken)
    {
        var cell = await _repository.GetByIdCell(request.id);
        return _mapper.Map<CellsDto>(cell);
    }
}

