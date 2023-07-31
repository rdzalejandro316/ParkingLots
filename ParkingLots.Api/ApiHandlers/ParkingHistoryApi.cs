using MediatR;
using ParkingLots.Api.Filters;
using ParkingLots.Application.Cell;
using ParkingLots.Application.ParkingHistorys;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Api.ApiHandlers;
public static class ParkingHistoryApi
{
    public static RouteGroupBuilder MapParkingHistory(this IEndpointRouteBuilder routeHandler)
    {
        routeHandler.MapGet("/", async (IMediator mediator) =>
        {
            return Results.Ok(await mediator.Send(new ParkingHistoryGetAll()));
        })
        .Produces(StatusCodes.Status200OK, typeof(IEnumerable<ParkingHistoryDto>));


        routeHandler.MapGet("/{id}", async (IMediator mediator, Guid id) =>
        {
            var parkingHistory = await mediator.Send(new ParkingHistoryGetById(id));
            return parkingHistory != null ? Results.Ok(parkingHistory) : Results.NotFound(parkingHistory);
        })
       .Produces(StatusCodes.Status200OK, typeof(ParkingHistoryDto));



        routeHandler.MapPut("/", async (IMediator mediator, [Validate] ParkingHistoryInputCreateCommand parkingHistoryInput) =>
        {
            var parkingHistory = await mediator.Send(parkingHistoryInput);
            return Results.Created(new Uri($"/api/parkingHistory/{parkingHistory.id}", UriKind.Relative), parkingHistory);
        })
        .Produces(statusCode: StatusCodes.Status201Created);

        return (RouteGroupBuilder)routeHandler;
    }
}
