namespace ParkingLots.Domain.Entities;
public class ParkingHistory
{
    public int ParkingHistoryId { get; set; }
    public int CellId { get; set; }
    public string LicensePlate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndingDate { get; set; }
}

