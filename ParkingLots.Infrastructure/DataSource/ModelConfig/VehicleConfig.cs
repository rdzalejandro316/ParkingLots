using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Infrastructure.DataSource.ModelConfig;

public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.Property(b => b.LicensePlate).IsRequired();
        builder.HasOne(y => y.TypeVehicle)
            .WithMany(x => x.Vehicles)
            .HasForeignKey(x => x.TypeVehicleId);
    }
}
