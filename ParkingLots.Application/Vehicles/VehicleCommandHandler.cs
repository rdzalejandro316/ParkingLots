using AutoMapper;
using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Ports;
using MediatR;

namespace ParkingLots.Application.Vehicles;
public class VehicleCommandCreateHandler : IRequestHandler<VehicleCreateCommand, VehicleDto>
{
    private readonly IVehiclesRepository _repository;
    private readonly IMapper _mapper;

    public VehicleCommandCreateHandler(IVehiclesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<VehicleDto> Handle(VehicleCreateCommand request, CancellationToken canTypeVehiclesationToken)
    {

        Vehicle vehicle = _mapper.Map<Vehicle>(request);
        var vehicles = await _repository.SaveVehicle(vehicle);
        return _mapper.Map<VehicleDto>(vehicles);
    }
}

public class VehicleCommandUpdateHandler : IRequestHandler<VehicleUpdateCommand, bool>
{
    private readonly IVehiclesRepository _repository;
    private readonly IMapper _mapper;

    public VehicleCommandUpdateHandler(IVehiclesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<bool> Handle(VehicleUpdateCommand request, CancellationToken canTypeVehiclesationToken)
    {
        Vehicle vehicle = _mapper.Map<Vehicle>(request);
        var succes = await _repository.UpdateVehicle(vehicle);
        return succes;
    }
}