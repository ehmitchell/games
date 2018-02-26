﻿// <auto-generated />
using GAMES.Data;
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
    [DbContext(typeof(GamesContext))]
    [Migration("20180226150158_removeCircularReferenceTeamScore")]
    partial class removeCircularReferenceTeamScore
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("GAMES.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("GameScoreOrder");

                    b.Property<int>("GameType");

                    b.Property<int?>("GamesInstanceId");

                    b.Property<bool>("IsTeamScore");

                    b.Property<string>("Name");

                    b.Property<string>("Rules");

                    b.HasKey("ID");

                    b.HasIndex("GamesInstanceId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GAMES.Models.GamesInstance", b =>
                {
                    b.Property<int>("GamesInstanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 2, 26, 9, 1, 57, 968, DateTimeKind.Local));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<int>("PersonTeamSize");

                    b.Property<string>("Tagline");

                    b.HasKey("GamesInstanceId");

                    b.ToTable("GamesInstances");
                });

            modelBuilder.Entity("GAMES.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsTeamParticipant");

                    b.Property<string>("Name");

                    b.Property<Guid?>("UserId");

                    b.HasKey("ID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("GAMES.Models.PersonScore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GameID");

                    b.Property<int?>("PersonID");

                    b.Property<int>("Score");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("PersonID");

                    b.ToTable("PersonScores");
                });

            modelBuilder.Entity("GAMES.Models.PersonTeam", b =>
                {
                    b.Property<int>("PersonTeamId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PersonID");

                    b.Property<int?>("TeamID");

                    b.HasKey("PersonTeamId");

                    b.HasIndex("PersonID");

                    b.HasIndex("TeamID");

                    b.ToTable("PersonTeams");
                });

            modelBuilder.Entity("GAMES.Models.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GamesInstanceId");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("GamesInstanceId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("GAMES.Models.TeamScore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GameID");

                    b.Property<int>("Score");

                    b.Property<int?>("TeamID");

                    b.HasKey("ID");

                    b.HasIndex("GameID");

                    b.HasIndex("TeamID");

                    b.ToTable("TeamScores");
                });

            modelBuilder.Entity("GAMES.Models.Game", b =>
                {
                    b.HasOne("GAMES.Models.GamesInstance", "GamesInstance")
                        .WithMany()
                        .HasForeignKey("GamesInstanceId");
                });

            modelBuilder.Entity("GAMES.Models.PersonScore", b =>
                {
                    b.HasOne("GAMES.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID");

                    b.HasOne("GAMES.Models.Person", "Person")
                        .WithMany("PersonScores")
                        .HasForeignKey("PersonID");
                });

            modelBuilder.Entity("GAMES.Models.PersonTeam", b =>
                {
                    b.HasOne("GAMES.Models.Person", "Person")
                        .WithMany("PersonTeams")
                        .HasForeignKey("PersonID");

                    b.HasOne("GAMES.Models.Team", "Team")
                        .WithMany("PersonTeams")
                        .HasForeignKey("TeamID");
                });

            modelBuilder.Entity("GAMES.Models.Team", b =>
                {
                    b.HasOne("GAMES.Models.GamesInstance", "GamesInstance")
                        .WithMany()
                        .HasForeignKey("GamesInstanceId");
                });

            modelBuilder.Entity("GAMES.Models.TeamScore", b =>
                {
                    b.HasOne("GAMES.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID");

                    b.HasOne("GAMES.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamID");
                });
#pragma warning restore 612, 618
        }
    }
}
