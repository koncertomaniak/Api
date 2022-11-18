﻿// <auto-generated />
using System;
using Koncertomaniak.Api.Module.Ticket.Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Koncertomaniak.Api.Module.Ticket.Infrastructure.Migrations
{
    [DbContext(typeof(TicketDbContext))]
    [Migration("20221117074352_CreateTicketProviders")]
    partial class CreateTicketProviders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);
            
            modelBuilder.Entity("Koncertomaniak.Api.Module.Ticket.Core.Entities.TicketProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EventsPK")
                        .HasColumnType("uuid");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventsPK");

                    b.ToTable("TicketProviders");
                });

            modelBuilder.Entity("Koncertomaniak.Api.Module.Ticket.Core.Entities.TicketProvider", b =>
                {
                    b.HasOne("Koncertomaniak.Api.Module.Event.Core.Entities.Event", "Events")
                        .WithMany()
                        .HasForeignKey("EventsPK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
