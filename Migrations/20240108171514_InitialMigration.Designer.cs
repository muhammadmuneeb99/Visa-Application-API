﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Visa_Application_API.DataAccessLayer.Helpers;

#nullable disable

namespace Visa_Application_API.Migrations
{
    [DbContext(typeof(VisaApiDBContext))]
    [Migration("20240108171514_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Visa_Application_API.Models.Applicant", b =>
                {
                    b.Property<int>("PkApplicantId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("int")
                        .HasColumnName("PK_ApplicantId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkApplicantId"), 1L, 1);

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PkApplicantId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("Visa_Application_API.Models.Application", b =>
                {
                    b.Property<int>("PkApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("int")
                        .HasColumnName("PK_ApplicationId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkApplicationId"), 1L, 1);

                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfExpiry")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MotherName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PassportNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PermanentAddress")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)");

                    b.Property<string>("PlaceOfIssue")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)");

                    b.Property<string>("PurposeOfEntry")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("VisaType")
                        .HasColumnType("int");

                    b.HasKey("PkApplicationId");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("Visa_Application_API.Models.ApplicationDocument", b =>
                {
                    b.Property<int>("PkDocumentId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("int")
                        .HasColumnName("PK_DocumentId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkDocumentId"), 1L, 1);

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkDocumentId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("ApplicationDocument");
                });

            modelBuilder.Entity("Visa_Application_API.Models.ApplicationStatus", b =>
                {
                    b.Property<int>("PkStatusId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("int")
                        .HasColumnName("PK_StatusId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkStatusId"), 1L, 1);

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkStatusId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("ApplicationStatus");
                });

            modelBuilder.Entity("Visa_Application_API.Models.SponsorOrHost", b =>
                {
                    b.Property<int>("PkId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("int")
                        .HasColumnName("PK_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameOfSponsorOrHost")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)");

                    b.Property<string>("PassportNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("PkId");

                    b.HasIndex("ApplicationId")
                        .IsUnique();

                    b.ToTable("SponsorOrHost");
                });

            modelBuilder.Entity("Visa_Application_API.Models.VisaTypes", b =>
                {
                    b.Property<int>("PkVisaTypeId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("int")
                        .HasColumnName("PK_VisaTypeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkVisaTypeId"), 1L, 1);

                    b.Property<string>("VisaType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PkVisaTypeId")
                        .HasName("PK_VisaType");

                    b.ToTable("VisaTypes");
                });

            modelBuilder.Entity("Visa_Application_API.Models.Application", b =>
                {
                    b.HasOne("Visa_Application_API.Models.Applicant", "Applicants")
                        .WithMany("Application")
                        .HasForeignKey("ApplicantId");

                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("Visa_Application_API.Models.ApplicationDocument", b =>
                {
                    b.HasOne("Visa_Application_API.Models.Application", "Application")
                        .WithMany("ApplicationDocument")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Visa_Application_API.Models.ApplicationStatus", b =>
                {
                    b.HasOne("Visa_Application_API.Models.Application", "Application")
                        .WithMany("ApplicationStatus")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Visa_Application_API.Models.SponsorOrHost", b =>
                {
                    b.HasOne("Visa_Application_API.Models.Application", "Application")
                        .WithOne("SponsorOrHost")
                        .HasForeignKey("Visa_Application_API.Models.SponsorOrHost", "ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Visa_Application_API.Models.Applicant", b =>
                {
                    b.Navigation("Application");
                });

            modelBuilder.Entity("Visa_Application_API.Models.Application", b =>
                {
                    b.Navigation("ApplicationDocument");

                    b.Navigation("ApplicationStatus");

                    b.Navigation("SponsorOrHost");
                });
#pragma warning restore 612, 618
        }
    }
}
