using MediatR;
using ParkingLots.Api.Filters;
using ParkingLots.Application.Cell;
using ParkingLots.Application.TypeVehicles;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Api.ApiHandlers;

public static class TypeVehicleApi
{
    public static RouteGroupBuilder MapTypeVehicle(this IEndpointRouteBuilder routeHandler)
    {
        routeHandler.MapGet("/", async (IMediator mediator) =>
        {
            return Results.Ok(await mediator.Send(new TypeVehiclesGetAll()));
        })
        .Produces(StatusCodes.Status200OK, typeof(IEnumerable<TypeVehicleDto>));


        routeHandler.MapGet("/{id}", async (IMediator mediator, Guid id) =>
        {
            var typeVehicle = await mediator.Send(new TypeVehiclesGetById(id));
            return typeVehicle != null ? Results.Ok(typeVehicle) : Results.NotFound(typeVehicle);
        })
       .Produces(StatusCodes.Status200OK, typeof(TypeVehicleDto));

        routeHandler.MapPut("/", async (IMediator mediator, [Validate] TypeVehiclesCreateCommand typeVehicles) =>
        {
            var typeVehicle = await mediator.Send(typeVehicles);
            return Results.Created(new Uri($"/api/typevehicle/{typeVehicle.id}", UriKind.Relative), typeVehicle);
        })
        .Produces(statusCode: StatusCodes.Status201Created);

        routeHandler.MapPost("/", async (IMediator mediator, [Validate] TypeVehiclesUpdateCommand typeVehicles) =>
        {
            var typeVehicle = await mediator.Send(typeVehicles);
            return Results.Ok(typeVehicle);
        })
        .Produces(statusCode: StatusCodes.Status200OK);

        return (RouteGroupBuilder)routeHandler;
    }
}
