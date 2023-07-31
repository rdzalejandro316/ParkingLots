namespace ParkingLots.Domain.Entities;

public class Vehicle : DomainEntity
{
    public string LicensePlate { get; set; }
    public int TypeVehicleId { get; set; }
    public int CylinderCapacity { get; set; }
}