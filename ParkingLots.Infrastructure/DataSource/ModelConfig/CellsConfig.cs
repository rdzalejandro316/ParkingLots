using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Infrastructure.DataSource.ModelConfig;
public class CellsConfig : IEntityTypeConfiguration<Cells>
{
    public void Configure(EntityTypeBuilder<Cells> builder)
    {
        builder.Property(b => b.CellNumber).IsRequired();
        builder.HasOne(y => y.TypeVehicle)
            .WithMany(x => x.Cells)
            .HasForeignKey(x => x.TypeVehicleId);
    }
}
