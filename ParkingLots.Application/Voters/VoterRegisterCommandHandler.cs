using ParkingLots.Domain.Dto;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Services;
using MediatR;


namespace ParkingLots.Application.Voters;

public class VoterRegisterCommandHandler : IRequestHandler<VoterRegisterCommand, VoterDto>
{
    private readonly RecordVoterService _service;

    public VoterRegisterCommandHandler(RecordVoterService service) =>
        _service = service ?? throw new ArgumentNullException(nameof(service));


   public async Task<VoterDto> Handle(VoterRegisterCommand request, CancellationToken cancellationToken)
    {
        var voterSaved =   await _service.RecordVoterAsync(
            new Voter(request.Nid, request.Dob, request.Origin), cancellationToken
        );

        return new VoterDto(voterSaved.Id, voterSaved.DateOfBirth, voterSaved.Origin);
    }
}
