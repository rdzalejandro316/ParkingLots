namespace ParkingLots.Domain.Entities;
public class TypeVehicle : DomainEntity
{
    public string NameTypeVehicle { get; init; }
    public List<Vehicle> Vehicles { get; set; }
    public List<Cells> Cells { get; set; }

}

