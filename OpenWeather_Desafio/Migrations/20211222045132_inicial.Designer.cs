﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenWeather_Desafio.Data;

namespace OpenWeather_Desafio.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211222045132_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("OpenWeather_Desafio.Data.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<double>("Temp")
                        .HasPrecision(10, 2)
                        .HasColumnType("double");

                    b.Property<double>("TempMax")
                        .HasPrecision(10, 2)
                        .HasColumnType("double");

                    b.Property<double>("TempMin")
                        .HasPrecision(10, 2)
                        .HasColumnType("double");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Teste",
                            Temp = 0.0,
                            TempMax = 0.0,
                            TempMin = 0.0,
                            dateTime = new DateTime(2021, 12, 22, 0, 51, 32, 383, DateTimeKind.Local).AddTicks(6571)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}