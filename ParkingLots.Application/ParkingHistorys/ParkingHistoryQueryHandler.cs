using AutoMapper;
using MediatR;
using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Ports;

namespace ParkingLots.Application.ParkingHistorys;

public class ParkingHistoryQueryHandler : IRequestHandler<ParkingHistoryGetAll, IEnumerable<ParkingHistoryDto>>
{
    private readonly IParkingHistoryRepository _repository;
    private readonly IMapper _mapper;
    public ParkingHistoryQueryHandler(IParkingHistoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ParkingHistoryDto>> Handle(ParkingHistoryGetAll request, CancellationToken cancellationToken)
    {
        var parkingHistory = await _repository.GetAllParkingHistory();
        return _mapper.Map<IEnumerable<ParkingHistoryDto>>(parkingHistory);
    }
}

public class ParkingHistoryQueryGetByIdHandler : IRequestHandler<ParkingHistoryGetById, ParkingHistoryDto>
{
    private readonly IParkingHistoryRepository _repository;
    private readonly IMapper _mapper;
    public ParkingHistoryQueryGetByIdHandler(IParkingHistoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ParkingHistoryDto> Handle(ParkingHistoryGetById request, CancellationToken cancellationToken)
    {
        var parkingHistory = await _repository.GetByIdParkingHistory(request.id);
        return _mapper.Map<ParkingHistoryDto>(parkingHistory);
    }
}