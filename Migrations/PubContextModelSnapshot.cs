﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using apiweb;

#nullable disable

namespace dot_webapi.Migrations
{
    [DbContext(typeof(PubContext))]
    partial class PubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("apiweb.models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
                            Name = "Actividades pendientes",
                            Weight = 20
                        },
                        new
                        {
                            Id = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"),
                            Name = "Actividades personales",
                            Weight = 50
                        });
                });

            modelBuilder.Entity("apiweb.models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"),
                            CategoryId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
                            Created_at = new DateTime(2023, 11, 7, 3, 19, 39, 38, DateTimeKind.Utc).AddTicks(9040),
                            Priority = 1,
                            Title = "Pago de servicios publicos",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                            CategoryId = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb402"),
                            Created_at = new DateTime(2023, 11, 7, 3, 19, 39, 38, DateTimeKind.Utc).AddTicks(9050),
                            Priority = 0,
                            Title = "Terminar de ver pelicula en netflix",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("apiweb.models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                            Email = "moises@morales.com",
                            Password = "$2a$11$AHPsx3NLvhsahNETVkY/7.XnOinRLn0/ASoSL4IY5pIrPf5yyKKHi"
                        });
                });

            modelBuilder.Entity("apiweb.models.Task", b =>
                {
                    b.HasOne("apiweb.models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apiweb.models.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("apiweb.models.Category", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("apiweb.models.User", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
