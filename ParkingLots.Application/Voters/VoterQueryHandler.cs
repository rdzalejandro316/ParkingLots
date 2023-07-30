using ParkingLots.Domain.Dto;
using ParkingLots.Domain.Ports;
using MediatR;

namespace ParkingLots.Application.Voters;

public class VoterQueryHandler : IRequestHandler<VoterQuery, VoterDto>
{
    private readonly IVoterRepository _repository;
    public VoterQueryHandler(IVoterRepository repository) => _repository = repository;
    

    public async Task<VoterDto> Handle(VoterQuery request, CancellationToken cancellationToken)
    {
        var voter = await _repository.SingleVoter(request.uid);        
        return new VoterDto(voter.Id, voter.DateOfBirth, voter.Origin);
    }
}