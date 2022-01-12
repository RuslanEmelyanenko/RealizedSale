﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Migrations
{
    [DbContext(typeof(SaleContext))]
    partial class SaleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewProject_RealizedSale.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColorDevice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("NewProject_RealizedSale.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("NewProject_RealizedSale.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("DeviceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("MemorySizeId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("MemorySizeId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("NewProject_RealizedSale.Models.DeviceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeviceTypes");
                });

            modelBuilder.Entity("NewProject_RealizedSale.Models.MemorySize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MemorySizeDevice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Memory");
                });

            modelBuilder.Entity("NewProject_RealizedSale.Models.RealizedSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<double>("TotalSum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeviceId");

                    b.ToTable("RealizedSales");
                });

            modelBuilder.Entity("NewProject_RealizedSale.Models.Device", b =>
                {
                    b.HasOne("NewProject_RealizedSale.Models.Color", "Color")
                        .WithMany("Devices")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewProject_RealizedSale.Models.DeviceType", "DeviceType")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewProject_RealizedSale.Models.MemorySize", "MemorySize")
                        .WithMany("Devices")
                        .HasForeignKey("MemorySizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("DeviceType");

                    b.Navigation("MemorySize");
                });

            modelBuilder.Entity("NewProject_RealizedSale.Models.RealizedSale", b =>
                {
                    b.HasOne("NewProject_RealizedSale.Models.Customer", "Customer")
                        .WithMany("RealizedSales")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewProject_RealizedSale.Models.Device", "Device")
                        .WithMany("RealizedSales")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("NewProject_RealizedSale.Models.Color", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("NewProject_RealizedSale.Models.Customer", b =>
                {
                    b.Navigation("RealizedSales");
                });

            modelBuilder.Entity("NewProject_RealizedSale.Models.Device", b =>
                {
                    b.Navigation("RealizedSales");
                });

            modelBuilder.Entity("NewProject_RealizedSale.Models.DeviceType", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("NewProject_RealizedSale.Models.MemorySize", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
