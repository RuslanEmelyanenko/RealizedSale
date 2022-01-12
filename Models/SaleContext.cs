using Microsoft.EntityFrameworkCore;

namespace NewProject_RealizedSale.Models
{
    public class SaleContext : DbContext
    {
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<MemorySize> Memory { get; set; }
        public DbSet<RealizedSale> RealizedSales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=EMELYANENKO;Database=NewProjectRealizedSaleDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Device
            modelBuilder.Entity<Device>()
                .HasOne<Color>(d => d.Color)
                .WithMany(d => d.Devices)
                .HasForeignKey(d => d.ColorId);

            modelBuilder.Entity<Device>()
                .HasOne<MemorySize>(d => d.MemorySize)
                .WithMany(s => s.Devices)
                .HasForeignKey(d => d.MemorySizeId);

            modelBuilder.Entity<Device>()
                .HasOne<DeviceType>(d => d.DeviceType)
                .WithMany(s => s.Devices)
                .HasForeignKey(d => d.DeviceTypeId);

            // Realized Sales
            modelBuilder.Entity<RealizedSale>()
                .HasOne<Device>(d => d.Device)
                .WithMany(d => d.RealizedSales)
                .HasForeignKey(d => d.DeviceId);

            modelBuilder.Entity<RealizedSale>()
                .HasOne<Customer>(d => d.Customer)
                .WithMany(s => s.RealizedSales)
                .HasForeignKey(d => d.CustomerId);
        }
    }
}
