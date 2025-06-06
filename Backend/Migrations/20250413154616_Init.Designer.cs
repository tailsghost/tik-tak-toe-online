﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tik_tak_toe_server.Database.Context;

#nullable disable

namespace tik_tak_toe_server.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20250413154616_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GameUser", b =>
                {
                    b.Property<Guid>("GamesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlayersId")
                        .HasColumnType("uuid");

                    b.HasKey("GamesId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("GameUser");
                });

            modelBuilder.Entity("tik_tak_toe_server.Database.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.PrimitiveCollection<string[]>("Field")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("GameOverAt")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid?>("WinnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("tik_tak_toe_server.Database.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameUser", b =>
                {
                    b.HasOne("tik_tak_toe_server.Database.Entities.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tik_tak_toe_server.Database.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tik_tak_toe_server.Database.Entities.Game", b =>
                {
                    b.HasOne("tik_tak_toe_server.Database.Entities.User", "Winner")
                        .WithMany("WinnerGames")
                        .HasForeignKey("WinnerId");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("tik_tak_toe_server.Database.Entities.User", b =>
                {
                    b.Navigation("WinnerGames");
                });
#pragma warning restore 612, 618
        }
    }
}
