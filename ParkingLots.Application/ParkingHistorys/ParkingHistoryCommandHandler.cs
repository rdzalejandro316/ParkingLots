using AutoMapper;
using MediatR;
using ParkingLots.Domain.Dtos;
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
        var parking = await _service.RecordInPutParkingHistoryAsync(parkingHistoryInputDto);
        var parkingDto = new ParkingHistoryDto(parking.Id, parking.CellId, parking.VehicleId, parking.StartDate, parking.EndingDate, parking.ValueParking);        
        return parkingDto;
    }
}
public class ParkingHistoryOutputUpdateCommandHandler : IRequestHandler<ParkingHistoryOutputUpdateCommand, ParkingHistoryDto>
{

    private readonly ParkingHistoryServices _service;
    private readonly IMapper _mapper;

    public ParkingHistoryOutputUpdateCommandHandler(ParkingHistoryServices service, IMapper mapper)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper;
    }


    public async Task<ParkingHistoryDto> Handle(ParkingHistoryOutputUpdateCommand request, CancellationToken cancellationToken)
    {
        ParkingHistoryOutPutDto parkingHistoryOutPutDto = _mapper.Map<ParkingHistoryOutPutDto>(request);
        var parking = await _service.RecordOutPutParkingHistoryAsync(parkingHistoryOutPutDto);
        var parkingDto = new ParkingHistoryDto(parking.Id, parking.CellId, parking.VehicleId, parking.StartDate, parking.EndingDate, parking.ValueParking);
        return parkingDto;
    }
}
