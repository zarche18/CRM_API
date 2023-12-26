﻿// <auto-generated />
using GoFive_CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoFive_CRM.Migrations
{
    [DbContext(typeof(GoFive_CRMDbContext))]
    [Migration("20231226033043_GoFive_CRM")]
    partial class GoFive_CRM
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GoFive_CRM.Core.Entites.Customers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("customers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Yangon, Myanmar",
                            Email = "alex@gmail.com",
                            Name = "Alex",
                            Notes = "Alex is a Developer!",
                            Phone = "9598888888"
                        },
                        new
                        {
                            ID = 2,
                            Address = "Yangon, Myanmar",
                            Email = "Jhon@gmail.com",
                            Name = "Jhon",
                            Notes = "Alex is a Developer!",
                            Phone = "9597777777"
                        },
                        new
                        {
                            ID = 3,
                            Address = "Yangon, Myanmar",
                            Email = "Eddie@gmail.com",
                            Name = "Eddie",
                            Notes = "Alex is a Product Develiry Manager!",
                            Phone = "9596666666"
                        },
                        new
                        {
                            ID = 4,
                            Address = "Yangon, Myanmar",
                            Email = "Sampar@gmail.com",
                            Name = "Sampar",
                            Notes = "Sampar is a QA!",
                            Phone = "9595555555"
                        },
                        new
                        {
                            ID = 5,
                            Address = "Yangon, Myanmar",
                            Email = "Aaron@gmail.com",
                            Name = "Aaron",
                            Notes = "Sampar is a Operation Manager!",
                            Phone = "9594444444"
                        },
                        new
                        {
                            ID = 6,
                            Address = "Yangon, Myanmar",
                            Email = "Doraalex@gmail.com",
                            Name = "Doraalex",
                            Notes = "Doraalex is a Project Manager!",
                            Phone = "9593333333"
                        },
                        new
                        {
                            ID = 7,
                            Address = "Yangon, Myanmar",
                            Email = "Kelvin@gmail.com",
                            Name = "Kelvin",
                            Notes = "Kelvin is a Support Lead!",
                            Phone = "9592222222"
                        },
                        new
                        {
                            ID = 8,
                            Address = "Yangon, Myanmar",
                            Email = "Andrew@gmail.com",
                            Name = "Andrew",
                            Notes = "Andrew is a API Developer!",
                            Phone = "9591111111"
                        },
                        new
                        {
                            ID = 9,
                            Address = "Yangon, Myanmar",
                            Email = "Mark@gmail.com",
                            Name = "Mark",
                            Notes = "Mark is a API Developer!",
                            Phone = "9599999999"
                        },
                        new
                        {
                            ID = 10,
                            Address = "Yangon, Myanmar",
                            Email = "Kusshi@gmail.com",
                            Name = "Kusshi",
                            Notes = "Kusshi is a support!",
                            Phone = "9598888888"
                        },
                        new
                        {
                            ID = 11,
                            Address = "Yangon, Myanmar",
                            Email = "Penny@gmail.com",
                            Name = "Penny",
                            Notes = "Penny is a support!",
                            Phone = "9597777777"
                        },
                        new
                        {
                            ID = 12,
                            Address = "Yangon, Myanmar",
                            Email = "Maria@gmail.com",
                            Name = "Maria",
                            Notes = "Maria is a support!",
                            Phone = "9597777777"
                        },
                        new
                        {
                            ID = 13,
                            Address = "Yangon, Myanmar",
                            Email = "Izi@gmail.com",
                            Name = "Izi",
                            Notes = "Maria is a QA!",
                            Phone = "9597777777"
                        },
                        new
                        {
                            ID = 14,
                            Address = "Yangon, Myanmar",
                            Email = "Chriatian@gmail.com",
                            Name = "Chriatian",
                            Notes = "Maria is a QA!",
                            Phone = "9597777777"
                        },
                        new
                        {
                            ID = 15,
                            Address = "Yangon, Myanmar",
                            Email = "Hwaimin@gmail.com",
                            Name = "Hwaimin",
                            Notes = "Hwaimin is a QA!",
                            Phone = "9597777777"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
