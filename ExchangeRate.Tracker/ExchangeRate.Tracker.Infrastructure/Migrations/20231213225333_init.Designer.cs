﻿// <auto-generated />
using System;
using ExchangeRate.Tracker.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExchangeRate.Tracker.Infrastructure.Migrations
{
    [DbContext(typeof(ExchangeRateDbContext))]
    [Migration("20231213225333_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExchangeRate.Tracker.Infrastructure.Models.ExchangeRateStoreModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Comment");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Currency");

                    b.Property<DateTime>("Store")
                        .HasColumnType("datetime2")
                        .HasColumnName("Store");

                    b.Property<DateTime>("TradingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("TradingDate");

                    b.Property<decimal>("Value")
                        .HasPrecision(2)
                        .HasColumnType("decimal(2,2)")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.ToTable("ExchangeRates", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
