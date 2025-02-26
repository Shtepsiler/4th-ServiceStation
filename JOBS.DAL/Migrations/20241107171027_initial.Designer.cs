﻿// <auto-generated />
using System;
using JOBS.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JOBS.DAL.Migrations
{
    [DbContext(typeof(ServiceStationDBContext))]
    [Migration("20241107171027_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JOBS.DAL.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MechanicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ModelAproved")
                        .HasColumnType("bit");

                    b.Property<float?>("ModelConfidence")
                        .HasColumnType("real");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("Pending");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MechanicId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JOBS.DAL.Entities.Mechanic", b =>
                {
                    b.Property<Guid>("MechanicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpecialisationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MechanicId");

                    b.HasIndex("SpecialisationId");

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("JOBS.DAL.Entities.MechanicsTasks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MechanicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("Pending");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("MechanicId");

                    b.ToTable("MechanicsTasks");
                });

            modelBuilder.Entity("JOBS.DAL.Entities.Specialisation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialisations");
                });

            modelBuilder.Entity("JOBS.DAL.Entities.Job", b =>
                {
                    b.HasOne("JOBS.DAL.Entities.Mechanic", "Mechanic")
                        .WithMany()
                        .HasForeignKey("MechanicId");

                    b.Navigation("Mechanic");
                });

            modelBuilder.Entity("JOBS.DAL.Entities.Mechanic", b =>
                {
                    b.HasOne("JOBS.DAL.Entities.Specialisation", "Specialisation")
                        .WithMany("Mechanics")
                        .HasForeignKey("SpecialisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialisation");
                });

            modelBuilder.Entity("JOBS.DAL.Entities.MechanicsTasks", b =>
                {
                    b.HasOne("JOBS.DAL.Entities.Job", "Job")
                        .WithMany("Tasks")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("JOBS.DAL.Entities.Mechanic", "Mechanic")
                        .WithMany("MechanicsTasks")
                        .HasForeignKey("MechanicId");

                    b.Navigation("Job");

                    b.Navigation("Mechanic");
                });

            modelBuilder.Entity("JOBS.DAL.Entities.Job", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("JOBS.DAL.Entities.Mechanic", b =>
                {
                    b.Navigation("MechanicsTasks");
                });

            modelBuilder.Entity("JOBS.DAL.Entities.Specialisation", b =>
                {
                    b.Navigation("Mechanics");
                });
#pragma warning restore 612, 618
        }
    }
}
