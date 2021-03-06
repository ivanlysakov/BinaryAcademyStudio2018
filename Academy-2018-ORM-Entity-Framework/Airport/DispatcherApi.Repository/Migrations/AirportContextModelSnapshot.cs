﻿// <auto-generated />
using DAL.Repository.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DAL.Repository.Migrations
{
    [DbContext(typeof(AirportContext))]
    partial class AirportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Repository.Models.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<long>("Lifetime");

                    b.Property<string>("Name")
                        .HasMaxLength(10);

                    b.Property<int?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Airplanes");
                });

            modelBuilder.Entity("DAL.Repository.Models.AirplaneType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<int>("Cargo");

                    b.Property<string>("Model");

                    b.HasKey("Id");

                    b.ToTable("AirplaneTypes");
                });

            modelBuilder.Entity("DAL.Repository.Models.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PilotId");

                    b.HasKey("Id");

                    b.HasIndex("PilotId");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("DAL.Repository.Models.Departure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AirplaneId");

                    b.Property<int?>("CrewId");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasMaxLength(7);

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("CrewId");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("DAL.Repository.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<string>("Departure");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<string>("Destination");

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("DAL.Repository.Models.Hostess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDay");

                    b.Property<int?>("CrewId");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30);

                    b.Property<string>("Lastname")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.ToTable("Hostesses");
                });

            modelBuilder.Entity("DAL.Repository.Models.Pilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDay");

                    b.Property<long>("Experience");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30);

                    b.Property<string>("Lastname")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("DAL.Repository.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FlightId");

                    b.Property<string>("FlightNumber");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("DAL.Repository.Models.Airplane", b =>
                {
                    b.HasOne("DAL.Repository.Models.AirplaneType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("DAL.Repository.Models.Crew", b =>
                {
                    b.HasOne("DAL.Repository.Models.Pilot", "Pilot")
                        .WithMany()
                        .HasForeignKey("PilotId");
                });

            modelBuilder.Entity("DAL.Repository.Models.Departure", b =>
                {
                    b.HasOne("DAL.Repository.Models.Airplane", "Airplane")
                        .WithMany()
                        .HasForeignKey("AirplaneId");

                    b.HasOne("DAL.Repository.Models.Crew", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewId");
                });

            modelBuilder.Entity("DAL.Repository.Models.Hostess", b =>
                {
                    b.HasOne("DAL.Repository.Models.Crew")
                        .WithMany("Hostesses")
                        .HasForeignKey("CrewId");
                });

            modelBuilder.Entity("DAL.Repository.Models.Ticket", b =>
                {
                    b.HasOne("DAL.Repository.Models.Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId");
                });
#pragma warning restore 612, 618
        }
    }
}
