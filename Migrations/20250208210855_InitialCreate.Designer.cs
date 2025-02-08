﻿// <auto-generated />
using MiataProjectTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MiataProjectTracker.Migrations
{
    [DbContext(typeof(MiataProjectTrackerContext))]
    [Migration("20250208210855_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("MiataProjectTracker.Models.Parts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("PartCost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("PartName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PartNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("PartStatus")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Parts");
                });
#pragma warning restore 612, 618
        }
    }
}
