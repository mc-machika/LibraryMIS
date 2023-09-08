﻿// <auto-generated />
using System;
using LibraryMIS.Services.BookAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryMIS.Services.BookAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230916141202_SeedBookTables")]
    partial class SeedBookTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryMIS.Services.BookAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "J. R. R. Tolkien",
                            CreateAt = new DateTime(2023, 9, 16, 16, 12, 2, 537, DateTimeKind.Local).AddTicks(237),
                            ISBN = "9780007525546",
                            Source = "Amazon",
                            State = "Available",
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 2,
                            Author = "J. R. R. Tolkien",
                            CreateAt = new DateTime(2023, 9, 16, 16, 12, 2, 537, DateTimeKind.Local).AddTicks(273),
                            ISBN = "9780007525546",
                            Source = "Amazon",
                            State = "Available",
                            Title = "The Hobbit"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
