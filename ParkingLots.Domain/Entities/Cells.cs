namespace ParkingLots.Domain.Entities;
public class Cells : DomainEntity
{    
    public string CellNumber { get; init; }
    public int TypeVehicleId { get; init; }
    public bool CellBusy { get; init; }
}

