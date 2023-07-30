using MediatR;
using ParkingLots.Api.Filters;
using ParkingLots.Application.Cell;
using ParkingLots.Domain.Dtos;

namespace ParkingLots.Api.ApiHandlers;

public static class CellsApi
{
    public static RouteGroupBuilder MapCells(this IEndpointRouteBuilder routeHandler)
    {
        routeHandler.MapGet("/", async (IMediator mediator) =>
        {
            return Results.Ok(await mediator.Send(new CellGetAll()));
        })
        .Produces(StatusCodes.Status200OK, typeof(IEnumerable<CellsDto>));


        routeHandler.MapGet("/{id}", async (IMediator mediator, Guid id) =>
        {
            var cell = await mediator.Send(new CellsGetById(id));
            return cell != null ? Results.Ok(cell) : Results.NotFound(cell);
        })
       .Produces(StatusCodes.Status200OK, typeof(CellsDto));      

        routeHandler.MapPut("/", async (IMediator mediator, [Validate] CellsCreateCommand cells) =>
        {
            var cell = await mediator.Send(cells);
            return Results.Created(new Uri($"/api/cells/{cell.id}", UriKind.Relative), cell);
        })
        .Produces(statusCode: StatusCodes.Status201Created);

        routeHandler.MapPost("/", async (IMediator mediator, [Validate] CellsUpdateCommand cells) =>
        {
            var cell = await mediator.Send(cells);
            return Results.Ok(cell);
        })
        .Produces(statusCode: StatusCodes.Status200OK);


        return (RouteGroupBuilder)routeHandler;
    }

}
