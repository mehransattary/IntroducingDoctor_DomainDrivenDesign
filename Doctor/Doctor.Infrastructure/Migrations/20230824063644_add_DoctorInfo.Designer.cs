﻿// <auto-generated />
using System;
using Doctor.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Doctor.Infrastructure.Migrations
{
    [DbContext(typeof(DoctorContext))]
    [Migration("20230824063644_add_DoctorInfo")]
    partial class add_DoctorInfo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Doctor.Domain.DoctorInformationAgg.DoctorInformation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MedicalLicenseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DoctorInformations", "doctorInfo");
                });

            modelBuilder.Entity("Doctor.Domain.DoctorInformationAgg.Specialization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("DoctorInformationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorInformationId");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("Doctor.Domain.MedicalServicesAgg.MedicalService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("MedicalServicies", "dbo");
                });

            modelBuilder.Entity("Doctor.Domain.DoctorInformationAgg.DoctorInformation", b =>
                {
                    b.OwnsMany("Doctor.Domain.DoctorInformationAgg.Address", "Addresses", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"));

                            b1.Property<string>("CodePosti")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<long>("DoctorInformationId")
                                .HasColumnType("bigint");

                            b1.Property<string>("TextAddress")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.HasKey("Id");

                            b1.HasIndex("DoctorInformationId");

                            b1.ToTable("Addresses", "doctorInfo");

                            b1.WithOwner()
                                .HasForeignKey("DoctorInformationId");
                        });

                    b.OwnsMany("Doctor.Domain.DoctorInformationAgg.ContactNumber", "ContactNumbers", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"));

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<long>("DoctorInformationId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Mobile")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)");

                            b1.HasKey("Id");

                            b1.HasIndex("DoctorInformationId");

                            b1.ToTable("ContactNumbers", "doctorInfo");

                            b1.WithOwner()
                                .HasForeignKey("DoctorInformationId");
                        });

                    b.Navigation("Addresses");

                    b.Navigation("ContactNumbers");
                });

            modelBuilder.Entity("Doctor.Domain.DoctorInformationAgg.Specialization", b =>
                {
                    b.HasOne("Doctor.Domain.DoctorInformationAgg.DoctorInformation", null)
                        .WithMany("Specializatiosn")
                        .HasForeignKey("DoctorInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Doctor.Domain.DoctorInformationAgg.DoctorInformation", b =>
                {
                    b.Navigation("Specializatiosn");
                });
#pragma warning restore 612, 618
        }
    }
}
