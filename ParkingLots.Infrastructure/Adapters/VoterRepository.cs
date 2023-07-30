using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Ports;
using ParkingLots.Infrastructure.Ports;

namespace ParkingLots.Infrastructure.Adapters
{
    [Repository]
    public class VoterRepository : IVoterRepository
    {
        readonly IRepository<Voter> _dataSource;
        public VoterRepository(IRepository<Voter> dataSource) => _dataSource = dataSource 
            ?? throw new ArgumentNullException(nameof(dataSource));        

        public async Task<Voter> SaveVoter(Voter v) => await _dataSource.AddAsync(v);

        public async Task<Voter> SingleVoter(Guid uid) => await _dataSource.GetOneAsync(uid);
        
        
    }
}
