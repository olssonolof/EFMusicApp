﻿// <auto-generated />
using System;
using EFMusicApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFMusicApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190305142237_Addedrelationship2")]
    partial class Addedrelationship2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFMusicApp.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtistsId");

                    b.Property<int>("ReleaseDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ArtistsId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("EFMusicApp.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.Property<int>("YearStarted");

                    b.HasKey("Id");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("EFMusicApp.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumsId");

                    b.Property<bool>("HasMusicVideo");

                    b.Property<int>("Length");

                    b.Property<string>("Lyrics");

                    b.Property<string>("Title");

                    b.Property<int>("TrackNumber");

                    b.HasKey("Id");

                    b.HasIndex("AlbumsId");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("EFMusicApp.Models.Album", b =>
                {
                    b.HasOne("EFMusicApp.Models.Artist", "Artists")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistsId");
                });

            modelBuilder.Entity("EFMusicApp.Models.Song", b =>
                {
                    b.HasOne("EFMusicApp.Models.Album", "Albums")
                        .WithMany("MyProperty")
                        .HasForeignKey("AlbumsId");
                });
#pragma warning restore 612, 618
        }
    }
}
