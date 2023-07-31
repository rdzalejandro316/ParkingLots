using AutoMapper;
using MediatR;
using ParkingLots.Application.Vehicles;
using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Services;

namespace ParkingLots.Application.ParkingHistorys;

public class ParkingHistoryInputCreateCommandHandler : IRequestHandler<ParkingHistoryInputCreateCommand, ParkingHistoryDto>
{

    private readonly ParkingHistoryServices _service;
    private readonly IMapper _mapper;

    public ParkingHistoryInputCreateCommandHandler(ParkingHistoryServices service, IMapper mapper)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper;
    }


    public async Task<ParkingHistoryDto> Handle(ParkingHistoryInputCreateCommand request, CancellationToken cancellationToken)
    {
        ParkingHistoryInputDto parkingHistoryInputDto = _mapper.Map<ParkingHistoryInputDto>(request);

        await _service.RecordParkingHistoryAsync(parkingHistoryInputDto);

        throw new NotImplementedException();
    }
}
