using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Infrastructure.DataSource.ModelConfig;

public class TypeVehicleConfig : IEntityTypeConfiguration<TypeVehicle>
{
    public void Configure(EntityTypeBuilder<TypeVehicle> builder)
    {
        builder.Property(b => b.NameTypeVehicle).IsRequired();
    }
}
