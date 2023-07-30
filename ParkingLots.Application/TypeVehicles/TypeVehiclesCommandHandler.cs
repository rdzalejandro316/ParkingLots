using AutoMapper;
using MediatR;
using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Ports;


namespace ParkingLots.Application.TypeVehicles;
public class TypeVehiclesCommandCreateHandler : IRequestHandler<TypeVehiclesCreateCommand, TypeVehicleDto>
{
    private readonly ITypeVehiclesRepository _repository;
    private readonly IMapper _mapper;

    public TypeVehiclesCommandCreateHandler(ITypeVehiclesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<TypeVehicleDto> Handle(TypeVehiclesCreateCommand request, CancellationToken canTypeVehiclesationToken)
    {

        TypeVehicle typeVehicle = _mapper.Map<TypeVehicle>(request);
        var typeVehicles = await _repository.SaveTypeVehicle(typeVehicle);
        return _mapper.Map<TypeVehicleDto>(typeVehicles);
    }

}

public class TypeVehiclesCommandUpdateHandler : IRequestHandler<TypeVehiclesUpdateCommand, bool>
{
    private readonly ITypeVehiclesRepository _repository;
    private readonly IMapper _mapper;

    public TypeVehiclesCommandUpdateHandler(ITypeVehiclesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<bool> Handle(TypeVehiclesUpdateCommand request, CancellationToken canTypeVehiclesationToken)
    {
        TypeVehicle typeVehicless = _mapper.Map<TypeVehicle>(request);
        var succes = await _repository.UpdateTypeVehicle(typeVehicless);
        return succes;
    }
}