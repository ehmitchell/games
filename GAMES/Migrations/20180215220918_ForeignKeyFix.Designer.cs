﻿// <auto-generated />
using GAMES.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GAMES.Migrations
{
    [DbContext(typeof(gamesContext))]
    [Migration("20180215220918_ForeignKeyFix")]
    partial class ForeignKeyFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("GAMES.Models.Game", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("GameScoreOrder");

                    b.Property<int>("GameType");

                    b.Property<bool>("IsTeamScore");

                    b.Property<string>("Name");

                    b.Property<string>("Rules");

                    b.HasKey("ID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("GAMES.Models.Person", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsJudge");

                    b.Property<string>("Name");

                    b.Property<Guid?>("TeamId");

                    b.Property<Guid?>("UserId");

                    b.HasKey("ID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("GAMES.Models.PersonScore", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GameIdID");

                    b.Property<Guid?>("PersonIdID");

                    b.Property<int>("Score");

                    b.HasKey("ID");

                    b.HasIndex("GameIdID");

                    b.HasIndex("PersonIdID");

                    b.ToTable("PersonScore");
                });

            modelBuilder.Entity("GAMES.Models.Team", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("GAMES.Models.TeamScore", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GameIdID");

                    b.Property<int>("Score");

                    b.Property<Guid?>("TeamIdID");

                    b.HasKey("ID");

                    b.HasIndex("GameIdID");

                    b.HasIndex("TeamIdID");

                    b.ToTable("TeamScore");
                });

            modelBuilder.Entity("GAMES.Models.PersonScore", b =>
                {
                    b.HasOne("GAMES.Models.Game", "GameId")
                        .WithMany()
                        .HasForeignKey("GameIdID");

                    b.HasOne("GAMES.Models.Person", "PersonId")
                        .WithMany()
                        .HasForeignKey("PersonIdID");
                });

            modelBuilder.Entity("GAMES.Models.TeamScore", b =>
                {
                    b.HasOne("GAMES.Models.Game", "GameId")
                        .WithMany()
                        .HasForeignKey("GameIdID");

                    b.HasOne("GAMES.Models.Team", "TeamId")
                        .WithMany()
                        .HasForeignKey("TeamIdID");
                });
#pragma warning restore 612, 618
        }
    }
}
