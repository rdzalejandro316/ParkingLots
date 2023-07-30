using ParkingLots.Domain.Entities;

namespace ParkingLots.Domain.Ports
{
    public interface IVoterRepository
    {
        Task<Voter> SaveVoter(Voter v);     
        Task<Voter> SingleVoter(Guid uid);   
        
    }
        
   
}

