﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication3.Models;

#nullable disable

namespace WebApplication3.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20240421060422_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("WebApplication3.Models.BankBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BranchManager")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BankBranches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BranchManager = "Abdulrahman",
                            EmployeeCount = 7,
                            LocationName = "Alshamyia",
                            LocationURL = "https://maps.app.goo.gl/k5DD4wvKX38Y6RFQ7"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}