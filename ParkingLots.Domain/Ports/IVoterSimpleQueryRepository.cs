using ParkingLots.Domain.Dto;

namespace ParkingLots.Domain.Ports
{
    public interface IVoterSimpleQueryRepository
    {
        Task<VoterDto> Single(Guid id);
    }
}

