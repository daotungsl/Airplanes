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
    [Migration("20190115183953_CreateDbUser")]
    partial class CreateDbUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirlineTicketResourceServer.Models.DbRewardPointsLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CreatedAt");

                    b.Property<long?>("DbUserId");

                    b.Property<string>("NameLog");

                    b.Property<string>("Note");

                    b.Property<int>("Points");

                    b.Property<long>("UId");

                    b.HasKey("Id");

                    b.HasIndex("DbUserId");

                    b.ToTable("DbRewardPointsLog");
                });

            modelBuilder.Entity("AirlineTicketResourceServer.Models.DbUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("EmailVerifyStatus");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("Gender");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("PhoneVerifyStatus");

                    b.Property<int>("RewardPoints");

                    b.Property<string>("Salt");

                    b.Property<int>("Status");

                    b.Property<long>("UId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("DbUser");
                });

            modelBuilder.Entity("AirlineTicketResourceServer.Models.DbRewardPointsLog", b =>
                {
                    b.HasOne("AirlineTicketResourceServer.Models.DbUser", "DbUser")
                        .WithMany("DbRewardPointsLogs")
                        .HasForeignKey("DbUserId");
                });
#pragma warning restore 612, 618
        }
    }
}