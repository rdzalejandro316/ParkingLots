using MediatR;
using ParkingLots.Api.Filters;
using ParkingLots.Application.TypeVehicles;
using ParkingLots.Application.Vehicles;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Api.ApiHandlers;

public static class VehicleApi
{
    public static RouteGroupBuilder MapVehicle(this IEndpointRouteBuilder routeHandler)
    {
        routeHandler.MapGet("/", async (IMediator mediator) =>
        {
            return Results.Ok(await mediator.Send(new VehicleGetAll()));
        })
        .Produces(StatusCodes.Status200OK, typeof(IEnumerable<VehicleDto>));


        routeHandler.MapGet("/{id}", async (IMediator mediator, Guid id) =>
        {
            var vehicle = await mediator.Send(new VehicleGetById(id));
            return vehicle != null ? Results.Ok(vehicle) : Results.NotFound(vehicle);
        })
       .Produces(StatusCodes.Status200OK, typeof(VehicleDto));

        routeHandler.MapPut("/", async (IMediator mediator, [Validate] VehicleCreateCommand vehicles) =>
        {
            var vehicle = await mediator.Send(vehicles);
            return Results.Created(new Uri($"/api/vehicle/{vehicle.id}", UriKind.Relative), vehicle);
        })
        .Produces(statusCode: StatusCodes.Status201Created);

        routeHandler.MapPost("/", async (IMediator mediator, [Validate] VehicleUpdateCommand vehicles) =>
        {
            var vehicle = await mediator.Send(vehicles);
            return Results.Ok(vehicle);
        })
        .Produces(statusCode: StatusCodes.Status200OK);

        return (RouteGroupBuilder)routeHandler;
    }
}