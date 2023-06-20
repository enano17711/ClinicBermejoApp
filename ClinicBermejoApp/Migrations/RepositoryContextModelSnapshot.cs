﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace ClinicBermejoApp.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Appointments.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AppointmentId");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateInit")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("NurseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("NurseId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Entities.Models.Appointments.AppointmentDoctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AppointmentDoctorId");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CommissionPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("DoctorId");

                    b.ToTable("AppointmentDoctors");
                });

            modelBuilder.Entity("Entities.Models.Items.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BrandId");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Entities.Models.Items.CategoryItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CategoryId");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CategoryItems");
                });

            modelBuilder.Entity("Entities.Models.Items.CategoryItemMN", b =>
                {
                    b.Property<Guid?>("CategoryItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryItemId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("CategoryItemMNs");
                });

            modelBuilder.Entity("Entities.Models.Items.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ItemId");

                    b.Property<Guid?>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Entities.Models.Items.ItemUnit", b =>
                {
                    b.Property<Guid?>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UnitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ItemId", "UnitId");

                    b.HasIndex("UnitId");

                    b.ToTable("ItemUnits");
                });

            modelBuilder.Entity("Entities.Models.Items.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UnitId");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Entities.Models.Movements.DetailMovement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DetailMovementId");

                    b.Property<string>("Allotment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsAllotment")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<Guid?>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MovementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<long>("SingleUnits")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("UnitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("MovementId");

                    b.HasIndex("UnitId");

                    b.ToTable("DetailMovements");
                });

            modelBuilder.Entity("Entities.Models.Movements.Movement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("MovementId");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("NoteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalCost")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("TotalQuantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("Entities.Models.Movements.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("NoteId");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Entities.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("PatientId");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ci")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClinicHistory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("NurseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("NurseId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Entities.Models.Services.CategoryService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CategoryServiceId");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CategoryServices");
                });

            modelBuilder.Entity("Entities.Models.Services.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ServiceId");

                    b.Property<Guid?>("CategoryServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Entities.Models.Services.ServiceDoctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ServiceDoctorId");

                    b.Property<decimal>("CommissionPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceDoctors");
                });

            modelBuilder.Entity("Entities.Models.Staff.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DoctorId");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ci")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegisterNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Specialty")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Entities.Models.Staff.Nurse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("NurseId");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ci")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegisterNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Specialty")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Nurses");
                });

            modelBuilder.Entity("Entities.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("SupplierId");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ci")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nit")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Entities.Models.Appointments.Appointment", b =>
                {
                    b.HasOne("Entities.Models.Staff.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId");

                    b.HasOne("Entities.Models.Staff.Nurse", "Nurse")
                        .WithMany("Appointments")
                        .HasForeignKey("NurseId");

                    b.HasOne("Entities.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId");

                    b.Navigation("Doctor");

                    b.Navigation("Nurse");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Entities.Models.Appointments.AppointmentDoctor", b =>
                {
                    b.HasOne("Entities.Models.Appointments.Appointment", "Appointment")
                        .WithMany("AppointmentDoctors")
                        .HasForeignKey("AppointmentId");

                    b.HasOne("Entities.Models.Staff.Doctor", "Doctor")
                        .WithMany("AppointmentDoctors")
                        .HasForeignKey("DoctorId");

                    b.Navigation("Appointment");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Entities.Models.Items.CategoryItemMN", b =>
                {
                    b.HasOne("Entities.Models.Items.CategoryItem", "CategoryItem")
                        .WithMany("CategoryItemMNs")
                        .HasForeignKey("CategoryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Items.Item", "Item")
                        .WithMany("CategoryItemMNs")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryItem");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Entities.Models.Items.Item", b =>
                {
                    b.HasOne("Entities.Models.Items.Brand", "Brand")
                        .WithMany("Items")
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Entities.Models.Items.ItemUnit", b =>
                {
                    b.HasOne("Entities.Models.Items.Item", "Item")
                        .WithMany("ItemUnits")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Items.Unit", "Unit")
                        .WithMany("ItemUnits")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Entities.Models.Movements.DetailMovement", b =>
                {
                    b.HasOne("Entities.Models.Items.Item", "Item")
                        .WithMany("DetailMovements")
                        .HasForeignKey("ItemId");

                    b.HasOne("Entities.Models.Movements.Movement", "Movement")
                        .WithMany("DetailMovements")
                        .HasForeignKey("MovementId");

                    b.HasOne("Entities.Models.Items.Unit", "Unit")
                        .WithMany("DetailMovements")
                        .HasForeignKey("UnitId");

                    b.Navigation("Item");

                    b.Navigation("Movement");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Entities.Models.Movements.Movement", b =>
                {
                    b.HasOne("Entities.Models.Movements.Note", "Note")
                        .WithMany("Movements")
                        .HasForeignKey("NoteId");

                    b.HasOne("Entities.Models.Supplier", "Supplier")
                        .WithMany("Movements")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Note");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Entities.Models.Patient", b =>
                {
                    b.HasOne("Entities.Models.Staff.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId");

                    b.HasOne("Entities.Models.Staff.Nurse", "Nurse")
                        .WithMany("Patients")
                        .HasForeignKey("NurseId");

                    b.Navigation("Doctor");

                    b.Navigation("Nurse");
                });

            modelBuilder.Entity("Entities.Models.Services.Service", b =>
                {
                    b.HasOne("Entities.Models.Services.CategoryService", "CategoryService")
                        .WithMany("Services")
                        .HasForeignKey("CategoryServiceId");

                    b.Navigation("CategoryService");
                });

            modelBuilder.Entity("Entities.Models.Services.ServiceDoctor", b =>
                {
                    b.HasOne("Entities.Models.Staff.Doctor", "Doctor")
                        .WithMany("ServiceDoctors")
                        .HasForeignKey("DoctorId");

                    b.HasOne("Entities.Models.Services.Service", "Service")
                        .WithMany("ServiceDoctors")
                        .HasForeignKey("ServiceId");

                    b.Navigation("Doctor");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Entities.Models.Appointments.Appointment", b =>
                {
                    b.Navigation("AppointmentDoctors");
                });

            modelBuilder.Entity("Entities.Models.Items.Brand", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Entities.Models.Items.CategoryItem", b =>
                {
                    b.Navigation("CategoryItemMNs");
                });

            modelBuilder.Entity("Entities.Models.Items.Item", b =>
                {
                    b.Navigation("CategoryItemMNs");

                    b.Navigation("DetailMovements");

                    b.Navigation("ItemUnits");
                });

            modelBuilder.Entity("Entities.Models.Items.Unit", b =>
                {
                    b.Navigation("DetailMovements");

                    b.Navigation("ItemUnits");
                });

            modelBuilder.Entity("Entities.Models.Movements.Movement", b =>
                {
                    b.Navigation("DetailMovements");
                });

            modelBuilder.Entity("Entities.Models.Movements.Note", b =>
                {
                    b.Navigation("Movements");
                });

            modelBuilder.Entity("Entities.Models.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Entities.Models.Services.CategoryService", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("Entities.Models.Services.Service", b =>
                {
                    b.Navigation("ServiceDoctors");
                });

            modelBuilder.Entity("Entities.Models.Staff.Doctor", b =>
                {
                    b.Navigation("AppointmentDoctors");

                    b.Navigation("Appointments");

                    b.Navigation("Patients");

                    b.Navigation("ServiceDoctors");
                });

            modelBuilder.Entity("Entities.Models.Staff.Nurse", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Entities.Models.Supplier", b =>
                {
                    b.Navigation("Movements");
                });
#pragma warning restore 612, 618
        }
    }
}
