﻿// <auto-generated />
using System;
using Koncertomaniak.Api.Module.Auth.Infrastructure.Dal;
using Koncertomaniak.Api.Module.Auth.Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Koncertomaniak.Api.Module.Auth.Infrastructure.Migrations
{
    [DbContext(typeof(AuthDbContext))]
    [Migration("20230318200020_AddApiClients")]
    partial class AddApiClients
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Koncertomaniak.Api.Module.Auth.Core.Entities.ApiClient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecretKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("ApiClients");
                });
#pragma warning restore 612, 618
        }
    }
}
