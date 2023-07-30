using ParkingLots.Domain.Dto;
using MediatR;

namespace ParkingLots.Application.Voters;

public record VoterQuery(
    Guid uid
    ) : IRequest<VoterDto>;

public record VoterSimpleQuery(
    Guid uid
    ) : IRequest<VoterDto>;
