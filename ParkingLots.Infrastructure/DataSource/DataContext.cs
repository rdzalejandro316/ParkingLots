using ParkingLots.Domain.Entities;
using ParkingLots.Infrastructure.DataSource.ModelConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ParkingLots.Infrastructure.DataSource;

public class DataContext : DbContext
{
    private readonly IConfiguration _config;
    public DataContext(DbContextOptions<DataContext> options, IConfiguration config) : base(options)
    {
        _config = config;

        //Database.EnsureDeleted();

        bool connect = Database.CanConnect();
        if (!connect) Database.EnsureCreated();        
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        var current = Environment.CurrentDirectory;
    //        string pathSqlLiteBd = Path.GetFullPath(Path.Combine(current, @"..\"));
    //        string BDSqlLite = @$"{pathSqlLiteBd}\BDSqlLite";
    //        string? sqlLiteExample = _config.GetSection("ConnectionStrings").GetSection("sqlLiteExample").Value;
    //        string DbPath = System.IO.Path.Join(BDSqlLite, sqlLiteExample);
    //        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    //    }
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
        {
            return;
        }

        //load all entity config from current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        // if using schema in db, uncomment the following line
        // modelBuilder.HasDefaultSchema(_config.GetValue<string>("SchemaName"));
        modelBuilder.Entity<Voter>();
        modelBuilder.Entity<ParkingHistory>();
        modelBuilder.Entity<TypeVehicle>();
        modelBuilder.Entity<Vehicle>();
        modelBuilder.Entity<ParkingHistory>();

        // ghost properties for audit
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var t = entityType.ClrType;
            if (typeof(DomainEntity).IsAssignableFrom(t))
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn");
                modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModifiedOn");
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}

