namespace ParkingLots.Domain.Entities;
public class TypeVehicle : DomainEntity
{
    public string NameTypeVehicle { get; init; }
    public decimal ValueHour { get; init; }
    public decimal ValueDay { get; init; }
    public bool Restriction { get; init; }
    public List<Vehicle> Vehicles { get; set; }
    public List<Cells> Cells { get; set; }
}

