﻿using AutoMapper;
using ParkingLots.Application.Cell;
using ParkingLots.Application.ParkingHistorys;
using ParkingLots.Application.TypeVehicles;
using ParkingLots.Application.Vehicles;
using ParkingLots.Domain.Dtos;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Application.Common.Mapper;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        CreateMap<ParkingHistory, ParkingHistoryDto>();        
        CreateMap<ParkingHistoryInputCreateCommand, ParkingHistoryInputDto>();
        CreateMap<ParkingHistoryOutputUpdateCommand, ParkingHistoryOutPutDto>();        

        CreateMap<TypeVehicle, TypeVehicleDto>();
        CreateMap<TypeVehiclesCreateCommand, TypeVehicle>();
        CreateMap<TypeVehiclesUpdateCommand, TypeVehicle>();

        CreateMap<Vehicle, VehicleDto>();
        CreateMap<VehicleCreateCommand, Vehicle>();
        CreateMap<VehicleUpdateCommand, Vehicle>();

        CreateMap<Cells, CellsDto>();
        CreateMap<CellsCreateCommand, Cells>();
        CreateMap<CellsUpdateCommand, Cells>();        
    }

}
