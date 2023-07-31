using AutoMapper;
using MediatR;
using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Ports;

namespace ParkingLots.Application.Vehicles;
public class VehiclesQueryHandler : IRequestHandler<VehicleGetAll, IEnumerable<VehicleDto>>
{
    private readonly IVehiclesRepository _repository;
    private readonly IMapper _mapper;
    public VehiclesQueryHandler(IVehiclesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VehicleDto>> Handle(VehicleGetAll request, CancellationToken cancellationToken)
    {
        var vehicle = await _repository.GetAllVehicle();
        return _mapper.Map<IEnumerable<VehicleDto>>(vehicle);
    }
}
public class VehiclesQueryGetByIdHandler : IRequestHandler<VehicleGetById, VehicleDto>
{
    private readonly IVehiclesRepository _repository;
    private readonly IMapper _mapper;
    public VehiclesQueryGetByIdHandler(IVehiclesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<VehicleDto> Handle(VehicleGetById request, CancellationToken cancellationToken)
    {
        var vehicle = await _repository.GetByIdVehicle(request.id);
        return _mapper.Map<VehicleDto>(vehicle);
    }
}