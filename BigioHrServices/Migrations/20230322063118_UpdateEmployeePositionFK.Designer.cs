﻿// <auto-generated />
using System;
using BigioHrServices.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BigioHrServices.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230322063118_UpdateEmployeePositionFK")]
    partial class UpdateEmployeePositionFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BigioHrServices.Db.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("DigitalSignature")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("digital_signature");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<int>("JatahCuti")
                        .HasColumnType("integer")
                        .HasColumnName("jatah_cuti");

                    b.Property<DateOnly>("JoinDate")
                        .HasColumnType("date")
                        .HasColumnName("join_date");

                    b.Property<DateTime>("LastUpdatePassword")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_update_password");

                    b.Property<string>("NIK")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nik");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<long?>("PositionId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("position_id");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sex");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.Property<string>("WorkLength")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("work_length");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("BigioHrServices.Db.Entities.Position", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("code");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<int?>("Level")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.ToTable("Position");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Code = "001",
                            CreatedBy = "",
                            CreatedDate = new DateTime(2023, 3, 22, 6, 31, 18, 155, DateTimeKind.Utc).AddTicks(7272),
                            IsActive = true,
                            Level = 2,
                            Name = "Pegawai"
                        },
                        new
                        {
                            Id = 2L,
                            Code = "002",
                            CreatedBy = "",
                            CreatedDate = new DateTime(2023, 3, 22, 6, 31, 18, 155, DateTimeKind.Utc).AddTicks(7297),
                            IsActive = true,
                            Level = 1,
                            Name = "Supervisor"
                        });
                });

            modelBuilder.Entity("BigioHrServices.Db.Entities.Employee", b =>
                {
                    b.HasOne("BigioHrServices.Db.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}
