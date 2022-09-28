﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentX.Data;

#nullable disable

namespace RentX.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarSpecification", b =>
                {
                    b.Property<Guid>("CarsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpecificationsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CarsId", "SpecificationsId");

                    b.HasIndex("SpecificationsId");

                    b.ToTable("CarSpecification");
                });

            modelBuilder.Entity("RentX.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("Daily_Rate")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FineAmount")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b55a6ed3-2837-4127-965f-b375af07c3e4"),
                            Available = true,
                            Brand = "Audi",
                            CategoryId = new Guid("ef354c3c-1a03-4003-971a-1d2af188d6c2"),
                            Created_At = new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1478),
                            Daily_Rate = 140,
                            Description = "O Audi A3 Sedan impressiona com o seu \r\n                        exterior esportivo e elegante. Progresso que se pode sentir.",
                            FineAmount = 100,
                            LicensePlate = "ABC 123A",
                            Name = "Audi A3"
                        },
                        new
                        {
                            Id = new Guid("c79dd509-55fc-4b14-86e2-73dd5f98dc26"),
                            Available = true,
                            Brand = "Nissan",
                            CategoryId = new Guid("381f85b0-9810-4331-a69d-d62733cc20ae"),
                            Created_At = new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1534),
                            Daily_Rate = 100,
                            Description = "O Nissan Versa Sedan impressiona com o seu \r\n                        exterior esportivo e elegante. Progresso que se pode sentir.",
                            FineAmount = 40,
                            LicensePlate = "ABC 123B",
                            Name = "Versa"
                        },
                        new
                        {
                            Id = new Guid("6c090713-ff4e-46f2-9e20-f3a49f5ac3bc"),
                            Available = true,
                            Brand = "Toyota",
                            CategoryId = new Guid("2089f4ab-9007-422e-9c9e-87b583423a4e"),
                            Created_At = new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1558),
                            Daily_Rate = 200,
                            Description = "O Corolla gli Sedan impressiona com o seu \r\n                        exterior esportivo e elegante. Progresso que se pode sentir.",
                            FineAmount = 140,
                            LicensePlate = "ABC 123C",
                            Name = "Corolla"
                        },
                        new
                        {
                            Id = new Guid("0defbea5-f8c9-47c5-801b-8d2269001dc0"),
                            Available = true,
                            Brand = "Hyundai",
                            CategoryId = new Guid("8a435f5f-c880-47e5-85a3-0d0451907aa8"),
                            Created_At = new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1583),
                            Daily_Rate = 120,
                            Description = "O HB20 Sedan impressiona com o seu \r\n                        exterior esportivo e elegante. Progresso que se pode sentir.",
                            FineAmount = 80,
                            LicensePlate = "ABC 123D",
                            Name = "HB20"
                        });
                });

            modelBuilder.Entity("RentX.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ef354c3c-1a03-4003-971a-1d2af188d6c2"),
                            Created_At = new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1822),
                            Description = "4 portas, teto solar",
                            Name = "esportivo"
                        },
                        new
                        {
                            Id = new Guid("381f85b0-9810-4331-a69d-d62733cc20ae"),
                            Created_At = new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1847),
                            Description = "Carro para momentos mais radicais",
                            Name = "suv"
                        },
                        new
                        {
                            Id = new Guid("2089f4ab-9007-422e-9c9e-87b583423a4e"),
                            Created_At = new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1869),
                            Description = "Carro para momentos mais radicais",
                            Name = "suv"
                        },
                        new
                        {
                            Id = new Guid("8a435f5f-c880-47e5-85a3-0d0451907aa8"),
                            Created_At = new DateTime(2022, 9, 27, 20, 58, 7, 534, DateTimeKind.Local).AddTicks(1893),
                            Description = "perfeito para a familia",
                            Name = "esportivo"
                        });
                });

            modelBuilder.Entity("RentX.Models.Specification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("RentX.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriverLicense")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarSpecification", b =>
                {
                    b.HasOne("RentX.Models.Car", null)
                        .WithMany()
                        .HasForeignKey("CarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentX.Models.Specification", null)
                        .WithMany()
                        .HasForeignKey("SpecificationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentX.Models.Car", b =>
                {
                    b.HasOne("RentX.Models.Category", null)
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentX.Models.Category", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
