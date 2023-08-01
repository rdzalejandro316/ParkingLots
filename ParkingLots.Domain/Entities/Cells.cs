namespace ParkingLots.Domain.Entities;
public class Cells : DomainEntity
{    
    public string CellNumber { get; init; }
    public Guid TypeVehicleId { get; set; }
    public bool CellBusy { get; set; }
    public TypeVehicle TypeVehicle { get; set; }

    public List<ParkingHistory> ParkingHistorys { get; set; }

}

