﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JogoCards.Migrations
{
    [DbContext(typeof(BancoDeDados))]
    [Migration("20240429154439_OnModelCreating")]
    partial class OnModelCreating
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CardName")
                        .HasColumnType("longtext");

                    b.Property<double>("Damage")
                        .HasColumnType("double");

                    b.Property<string>("Element")
                        .HasColumnType("longtext");

                    b.Property<int>("ManaCost")
                        .HasColumnType("int");

                    b.Property<int>("PersonagemId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonagemId1")
                        .HasColumnType("int");

                    b.Property<double>("TaxaDrop")
                        .HasColumnType("double");

                    b.Property<string>("TypeCard")
                        .HasColumnType("longtext");

                    b.HasKey("CardId");

                    b.HasIndex("PersonagemId");

                    b.HasIndex("PersonagemId1");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Personagem", b =>
                {
                    b.Property<int>("PersonagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .HasColumnType("longtext");

                    b.Property<string>("Element")
                        .HasColumnType("longtext");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<string>("PersonagemName")
                        .HasColumnType("longtext");

                    b.Property<string>("Weakness")
                        .HasColumnType("longtext");

                    b.HasKey("PersonagemId");

                    b.ToTable("Personagens");
                });

            modelBuilder.Entity("Card", b =>
                {
                    b.HasOne("Personagem", "Personagem")
                        .WithMany()
                        .HasForeignKey("PersonagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Personagem", null)
                        .WithMany("Cards")
                        .HasForeignKey("PersonagemId1");

                    b.Navigation("Personagem");
                });

            modelBuilder.Entity("Personagem", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
