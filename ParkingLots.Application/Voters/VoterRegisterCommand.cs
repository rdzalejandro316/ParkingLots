using ParkingLots.Domain.Dto;
using MediatR;


namespace ParkingLots.Application.Voters;

public record VoterRegisterCommand(
    string Nid, string Origin, DateTime Dob
    ) : IRequest<VoterDto>; 

