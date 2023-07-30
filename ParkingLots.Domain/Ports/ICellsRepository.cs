using ParkingLots.Domain.Entities;

namespace ParkingLots.Domain.Ports;
public interface ICellsRepository
{
    Task<IEnumerable<Cells>> GetAllCell();
    Task<Cells> GetByIdCell(Guid id);

    Task<Cells> SaveCell(Cells cells);
    Task<bool> UpdateCell(Cells cells);
    Task<bool> DeleteCell(Cells cells);
}
