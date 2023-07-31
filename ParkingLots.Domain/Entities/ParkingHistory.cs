namespace ParkingLots.Domain.Entities;
public class ParkingHistory : DomainEntity
{    
    public Guid CellId { get; set; }
    public Guid VehicleId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndingDate { get; set; }
}

