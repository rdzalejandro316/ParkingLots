namespace ParkingLots.Domain.Entities;
public class ParkingHistory : DomainEntity
{    
    public Guid CellId { get; set; }
    public Guid VehicleId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public decimal ValueParking { get; set; }
    public Cells Cells { get; set; }
    public Vehicle Vehicle { get; set; }
}

