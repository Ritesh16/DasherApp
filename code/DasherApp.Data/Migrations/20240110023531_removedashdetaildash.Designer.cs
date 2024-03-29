﻿// <auto-generated />
using System;
using DasherApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DasherApp.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240110023531_removedashdetaildash")]
    partial class removedashdetaildash
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DasherApp.Data.Entity.DailyDash", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<double>("Mileage")
                        .HasColumnType("float");

                    b.Property<DateTime>("RowCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RowUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("DailyDash");
                });

            modelBuilder.Entity("DasherApp.Data.Entity.DashDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DailyDashId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderCreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDeliveryTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderPickupTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Restaurant")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("RowCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RowUpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DailyDashId");

                    b.ToTable("DashDetail");
                });

            modelBuilder.Entity("DasherApp.Data.Entity.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RowCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RowUpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("DasherApp.Data.Entity.DailyDash", b =>
                {
                    b.HasOne("DasherApp.Data.Entity.Location", "Location")
                        .WithMany("DailyDashes")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("DasherApp.Data.Entity.DashDetail", b =>
                {
                    b.HasOne("DasherApp.Data.Entity.DailyDash", "DailyDash")
                        .WithMany("DashDetails")
                        .HasForeignKey("DailyDashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DailyDash");
                });

            modelBuilder.Entity("DasherApp.Data.Entity.DailyDash", b =>
                {
                    b.Navigation("DashDetails");
                });

            modelBuilder.Entity("DasherApp.Data.Entity.Location", b =>
                {
                    b.Navigation("DailyDashes");
                });
#pragma warning restore 612, 618
        }
    }
}
