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
    [Migration("20230125165557_updateDataBaseDataNew")]
    partial class updateDataBaseDataNew
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Qualification")
                        .HasColumnType("real");

                    b.Property<decimal>("Rental_price")
                        .HasColumnType("numeric");

                    b.Property<bool>("SoldOut")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MovieId");

                    b.ToTable("Movie", (string)null);
                });

            modelBuilder.Entity("Models.Stock", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.Property<int>("Left")
                        .HasColumnType("integer");

                    b.Property<int>("Rented")
                        .HasColumnType("integer");

                    b.Property<int>("Reserved")
                        .HasColumnType("integer");

                    b.Property<int>("Total")
                        .HasColumnType("integer");

                    b.HasKey("MovieId");

                    b.ToTable("Stocks");
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

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Models.UserMovie", b =>
                {
                    b.Property<Guid>("UserMovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Booking")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataRent")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Delivery")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Fine_value")
                        .HasColumnType("numeric");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.Property<int>("Movies_total")
                        .HasColumnType("integer");

                    b.Property<decimal>("Rental_value")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("Trem")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("UserMovieId");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMovies");
                });

            modelBuilder.Entity("Models.Stock", b =>
                {
                    b.HasOne("Models.Movie", "Movie")
                        .WithOne("Stock")
                        .HasForeignKey("Models.Stock", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("Models.Movie", b =>
                {
                    b.Navigation("Stock")
                        .IsRequired();

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
