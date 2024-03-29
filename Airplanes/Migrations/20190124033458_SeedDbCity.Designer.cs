﻿// <auto-generated />
using System;
using Airplanes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Airplanes.Migrations
{
    [DbContext(typeof(AirplanesContext))]
    [Migration("20190124033458_SeedDbCity")]
    partial class SeedDbCity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Airplanes.Models.Custom.AirplanesUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<int>("Gender");

                    b.Property<string>("IdNumber");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("RewardPoints");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<long>("UId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Airplanes.Models.DbAirport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirportName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<long>("DbCityId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("DbCityId")
                        .IsUnique();

                    b.ToTable("DbAirport");
                });

            modelBuilder.Entity("Airplanes.Models.DbAvailableSeat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<long>("DbFlightId");

                    b.Property<int>("Quantity");

                    b.Property<int>("RestTicket");

                    b.Property<long>("TicketClassId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("DbFlightId");

                    b.HasIndex("TicketClassId");

                    b.ToTable("DbAvailableSeat");
                });

            modelBuilder.Entity("Airplanes.Models.DbCity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirportStatus");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<long>("DbCountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<long>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("DbCountryId");

                    b.ToTable("DbCity");
                });

            modelBuilder.Entity("Airplanes.Models.DbCountry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("DbCountry");
                });

            modelBuilder.Entity("Airplanes.Models.DbFlight", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<long>("DbPlaneId");

                    b.Property<long>("DbRouteId");

                    b.Property<int>("FlightDuration");

                    b.Property<DateTime>("FlightTime");

                    b.Property<string>("RollNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Status");

                    b.Property<int>("TimeOfTransit");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("DbPlaneId");

                    b.HasIndex("DbRouteId");

                    b.ToTable("DbFlight");
                });

            modelBuilder.Entity("Airplanes.Models.DbNews", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("DbNews");
                });

            modelBuilder.Entity("Airplanes.Models.DbOrder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Quantity");

                    b.Property<int>("Status");

                    b.Property<string>("UId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("UId");

                    b.ToTable("DbOrder");
                });

            modelBuilder.Entity("Airplanes.Models.DbPassenger", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Gender");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("UId");

                    b.ToTable("DbPassenger");
                });

            modelBuilder.Entity("Airplanes.Models.DbPlane", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<string>("MadeIn")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("PlaneName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UrlTemplate")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("DbPlane");
                });

            modelBuilder.Entity("Airplanes.Models.DbRewardPointsLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("NameLog")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("Points");

                    b.Property<string>("UId");

                    b.HasKey("Id");

                    b.HasIndex("UId");

                    b.ToTable("DbRewardPointsLog");
                });

            modelBuilder.Entity("Airplanes.Models.DbRoute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FromAirport")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ToAirport")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("DbRoute");
                });

            modelBuilder.Entity("Airplanes.Models.DbTicket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<long>("DbFlightId");

                    b.Property<long>("DbOrderId");

                    b.Property<long>("DbPassengerId");

                    b.Property<long>("DbTicketClassId");

                    b.Property<int>("Price");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("DbFlightId");

                    b.HasIndex("DbOrderId");

                    b.HasIndex("DbPassengerId")
                        .IsUnique();

                    b.HasIndex("DbTicketClassId");

                    b.ToTable("DbTicket");
                });

            modelBuilder.Entity("Airplanes.Models.DbTicketClass", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Price");

                    b.Property<string>("TicketClassName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("DbTicketClass");
                });

            modelBuilder.Entity("Airplanes.Models.DbTransit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<long>("DbAirportId");

                    b.Property<long>("DbFlightId");

                    b.Property<int>("DelayTime");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("DbAirportId");

                    b.HasIndex("DbFlightId")
                        .IsUnique();

                    b.ToTable("DbTransit");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Airplanes.Models.DbAirport", b =>
                {
                    b.HasOne("Airplanes.Models.DbCity", "DbCity")
                        .WithOne("DbAirPort")
                        .HasForeignKey("Airplanes.Models.DbAirport", "DbCityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Airplanes.Models.DbAvailableSeat", b =>
                {
                    b.HasOne("Airplanes.Models.DbFlight", "DbFlight")
                        .WithMany("AvailableSeats")
                        .HasForeignKey("DbFlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Airplanes.Models.DbTicketClass", "DbTicketClass")
                        .WithMany("DbAvailableSeats")
                        .HasForeignKey("TicketClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Airplanes.Models.DbCity", b =>
                {
                    b.HasOne("Airplanes.Models.DbCountry", "DbCountry")
                        .WithMany("DbCities")
                        .HasForeignKey("DbCountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Airplanes.Models.DbFlight", b =>
                {
                    b.HasOne("Airplanes.Models.DbPlane", "DbPlane")
                        .WithMany("DbFlights")
                        .HasForeignKey("DbPlaneId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Airplanes.Models.DbRoute", "DbRoute")
                        .WithMany("DbFlights")
                        .HasForeignKey("DbRouteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Airplanes.Models.DbOrder", b =>
                {
                    b.HasOne("Airplanes.Models.Custom.AirplanesUser", "AirplanesUser")
                        .WithMany("DbOrders")
                        .HasForeignKey("UId");
                });

            modelBuilder.Entity("Airplanes.Models.DbPassenger", b =>
                {
                    b.HasOne("Airplanes.Models.Custom.AirplanesUser", "AirplanesUser")
                        .WithMany("DbPassengers")
                        .HasForeignKey("UId");
                });

            modelBuilder.Entity("Airplanes.Models.DbRewardPointsLog", b =>
                {
                    b.HasOne("Airplanes.Models.Custom.AirplanesUser", "AirplanesUser")
                        .WithMany("DbRewardPointsLogs")
                        .HasForeignKey("UId");
                });

            modelBuilder.Entity("Airplanes.Models.DbTicket", b =>
                {
                    b.HasOne("Airplanes.Models.DbFlight", "DbFlight")
                        .WithMany("DbTickets")
                        .HasForeignKey("DbFlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Airplanes.Models.DbOrder", "DbOrder")
                        .WithMany("DbTickets")
                        .HasForeignKey("DbOrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Airplanes.Models.DbPassenger", "DbPassenger")
                        .WithOne("DbTicket")
                        .HasForeignKey("Airplanes.Models.DbTicket", "DbPassengerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Airplanes.Models.DbTicketClass", "DbTicketClass")
                        .WithMany("DbTickets")
                        .HasForeignKey("DbTicketClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Airplanes.Models.DbTransit", b =>
                {
                    b.HasOne("Airplanes.Models.DbAirport", "DbAirPort")
                        .WithMany()
                        .HasForeignKey("DbAirportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Airplanes.Models.DbFlight", "DbFlight")
                        .WithOne("DbTransit")
                        .HasForeignKey("Airplanes.Models.DbTransit", "DbFlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Airplanes.Models.Custom.AirplanesUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Airplanes.Models.Custom.AirplanesUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Airplanes.Models.Custom.AirplanesUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Airplanes.Models.Custom.AirplanesUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
