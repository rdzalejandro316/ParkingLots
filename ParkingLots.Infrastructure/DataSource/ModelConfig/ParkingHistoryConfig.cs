using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Infrastructure.DataSource.ModelConfig;
public class ParkingHistoryConfig : IEntityTypeConfiguration<ParkingHistory>
{
    public void Configure(EntityTypeBuilder<ParkingHistory> builder)
    {
        builder.Property(b => b.CellId).IsRequired();
        builder.Property(b => b.VehicleId).IsRequired();        
        
        builder.Property(b => b.EndingDate).IsRequired(false);   

        builder.HasOne(y => y.Cells)
            .WithMany(x => x.ParkingHistorys)
            .HasForeignKey(x => x.CellId);

        builder.HasOne(y => y.Vehicle)
            .WithMany(x => x.ParkingHistorys)
            .HasForeignKey(x => x.VehicleId);
    }
}
