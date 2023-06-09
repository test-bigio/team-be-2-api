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
    [Migration("20230322105711_AddTableHistoryPassword")]
    partial class AddTableHistoryPassword
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BigioHrServices.Db.Entities.AuditLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Activity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("activity");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("detail");

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("module_name");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.ToTable("AuditLog");
                });

            modelBuilder.Entity("BigioHrServices.Db.Entities.DelegationMatrix", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<long?>("EmployeeBackupId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("employee_backup_id");

                    b.Property<long?>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("employee_id");

                    b.Property<int>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeBackupId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("DelegationMatrix");
                });

            modelBuilder.Entity("BigioHrServices.Db.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("DigitalSignature")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("digital_signature");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsOnLeave")
                        .HasColumnType("boolean")
                        .HasColumnName("is_on_leave");

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

                    b.Property<string>("OTP")
                        .HasColumnType("text")
                        .HasColumnName("otp");

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

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
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

            modelBuilder.Entity("BigioHrServices.Db.Entities.HistoryDigitalSignature", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("DigitalSignature")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("digital_signature");

                    b.Property<long?>("EmployeeId")
                        .HasColumnType("bigint")
                        .HasColumnName("employee_id");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("HistoryDigitalSignature");
                });

            modelBuilder.Entity("BigioHrServices.Db.Entities.HistoryPassword", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("EmployeeId")
                        .HasColumnType("bigint")
                        .HasColumnName("employee_id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("HistoryPassword");
                });

            modelBuilder.Entity("BigioHrServices.Db.Entities.Leave", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<long?>("DelegationMatrixId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("delegation_matrix_id");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint")
                        .HasColumnName("employee_id");

                    b.Property<bool>("IsApprove")
                        .HasColumnType("boolean")
                        .HasColumnName("is_approve");

                    b.Property<string>("TaskDetail")
                        .HasColumnType("text")
                        .HasColumnName("task_detail");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.Property<DateOnly>("leaveDate")
                        .HasColumnType("date")
                        .HasColumnName("leave_date");

                    b.Property<string>("reviewedBy")
                        .HasColumnType("text")
                        .HasColumnName("reviewed_by");

                    b.Property<DateTime?>("reviewedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("reviewed_date");

                    b.HasKey("Id");

                    b.HasIndex("DelegationMatrixId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Leave");
                });

            modelBuilder.Entity("BigioHrServices.Db.Entities.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint")
                        .HasColumnName("employee_id");

                    b.Property<bool>("IsView")
                        .HasColumnType("boolean")
                        .HasColumnName("is_view");

                    b.Property<long>("LeaveId")
                        .HasColumnType("bigint")
                        .HasColumnName("leave_id");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LeaveId");

                    b.ToTable("Notification");
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

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
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
                            CreatedDate = new DateTime(2023, 3, 22, 12, 0, 0, 0, DateTimeKind.Utc),
                            IsActive = true,
                            Level = 2,
                            Name = "Pegawai"
                        },
                        new
                        {
                            Id = 2L,
                            Code = "002",
                            CreatedDate = new DateTime(2023, 3, 22, 12, 0, 0, 0, DateTimeKind.Utc),
                            IsActive = true,
                            Level = 1,
                            Name = "Supervisor"
                        });
                });

            modelBuilder.Entity("BigioHrServices.Db.Entities.DelegationMatrix", b =>
                {
                    b.HasOne("BigioHrServices.Db.Entities.Employee", "EmployeeBackup")
                        .WithMany()
                        .HasForeignKey("EmployeeBackupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BigioHrServices.Db.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("EmployeeBackup");
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

            modelBuilder.Entity("BigioHrServices.Db.Entities.HistoryDigitalSignature", b =>
                {
                    b.HasOne("BigioHrServices.Db.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BigioHrServices.Db.Entities.HistoryPassword", b =>
                {
                    b.HasOne("BigioHrServices.Db.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BigioHrServices.Db.Entities.Leave", b =>
                {
                    b.HasOne("BigioHrServices.Db.Entities.DelegationMatrix", "DelegationMatrix")
                        .WithMany()
                        .HasForeignKey("DelegationMatrixId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BigioHrServices.Db.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DelegationMatrix");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("BigioHrServices.Db.Entities.Notification", b =>
                {
                    b.HasOne("BigioHrServices.Db.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BigioHrServices.Db.Entities.Leave", "Leave")
                        .WithMany()
                        .HasForeignKey("LeaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Leave");
                });
#pragma warning restore 612, 618
        }
    }
}
