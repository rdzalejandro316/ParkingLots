using System.Reflection.Metadata;

namespace ParkingLots.Domain.Entities;

public class Vehicle : DomainEntity
{
    public string LicensePlate { get; set; }
    public Guid TypeVehicleId { get; set; }
    public int CylinderCapacity { get; set; }
    public TypeVehicle TypeVehicle { get; set; }
    public List<ParkingHistory> ParkingHistorys { get; set; }
}