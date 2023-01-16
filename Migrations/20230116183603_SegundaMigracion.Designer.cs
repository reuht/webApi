﻿// <auto-generated />
using System;
using ContextAplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backEnd.Migrations
{
    [DbContext(typeof(AplicationContext))]
    [Migration("20230116183603_SegundaMigracion")]
    partial class SegundaMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Gender", b =>
                {
                    b.Property<Guid>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("NameGender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("GenderId");

                    b.ToTable("Gender", (string)null);
                });

            modelBuilder.Entity("Models.Movie", b =>
                {
                    b.Property<Guid>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Actors")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Qualification")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("units")
                        .HasColumnType("integer");

                    b.HasKey("MovieId");

                    b.ToTable("Movie", (string)null);
                });

            modelBuilder.Entity("Models.MovieGender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieGender", (string)null);
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Roluser")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Models.UserMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Booking")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataRent")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Delivery")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMovie", (string)null);
                });

            modelBuilder.Entity("Models.MovieGender", b =>
                {
                    b.HasOne("Models.Gender", "Gender")
                        .WithMany("MovieGenders")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Movie", "Movie")
                        .WithMany("MovieGenders")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Models.UserMovie", b =>
                {
                    b.HasOne("Models.Movie", "Movie")
                        .WithMany("UserMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany("UserMovies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Gender", b =>
                {
                    b.Navigation("MovieGenders");
                });

            modelBuilder.Entity("Models.Movie", b =>
                {
                    b.Navigation("MovieGenders");

                    b.Navigation("UserMovies");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("UserMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
