using AutoMapper;
using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Application.Common.Mapper;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        CreateMap<ParkingLots.Domain.Entities.Cells, CellsDto>();

    }

}
