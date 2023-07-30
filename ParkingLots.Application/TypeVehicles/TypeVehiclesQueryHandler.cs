using AutoMapper;
using MediatR;
using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Ports;

namespace ParkingLots.Application.TypeVehicles;

public class TypeVehiclesQueryHandler : IRequestHandler<TypeVehiclesGetAll, IEnumerable<TypeVehicleDto>>
{
    private readonly ITypeVehiclesRepository _repository;
    private readonly IMapper _mapper;
    public TypeVehiclesQueryHandler(ITypeVehiclesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TypeVehicleDto>> Handle(TypeVehiclesGetAll request, CancellationToken cancellationToken)
    {
        var typeVehicle = await _repository.GetAllTypeVehicle();
        return _mapper.Map<IEnumerable<TypeVehicleDto>>(typeVehicle);
    }
}

public class TypeVehiclesQueryGetByIdHandler : IRequestHandler<TypeVehiclesGetById, TypeVehicleDto>
{
    private readonly ITypeVehiclesRepository _repository;
    private readonly IMapper _mapper;
    public TypeVehiclesQueryGetByIdHandler(ITypeVehiclesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TypeVehicleDto> Handle(TypeVehiclesGetById request, CancellationToken cancellationToken)
    {
        var typeVehicle = await _repository.GetByIdTypeVehicle(request.id);
        return _mapper.Map<TypeVehicleDto>(typeVehicle);
    }
}
