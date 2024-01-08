using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Visa_Application_API.Models;

namespace Visa_Application_API.DataAccessLayer.Helpers
{
    public partial class VisaApiDBContext : DbContext
    {
        public VisaApiDBContext()
        {
        }

        public VisaApiDBContext(DbContextOptions<VisaApiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ApplicationDocument> ApplicationDocument { get; set; }
        public virtual DbSet<ApplicationStatus> ApplicationStatus { get; set; }
        public virtual DbSet<SponsorOrHost> SponsorOrHost { get; set; }
        public virtual DbSet<VisaTypes> VisaTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<VisaTypes>(entity =>
            {
                entity.HasKey(e => e.PkVisaTypeId)
                    .HasName("PK_VisaType");

                entity.Property(e => e.PkVisaTypeId)
                    .HasColumnName("PK_VisaTypeId")
                    .HasMaxLength(128);

                entity.Property(e => e.VisaType).HasMaxLength(100);
            });

            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.HasKey(e => e.PkApplicantId);

                entity.Property(e => e.PkApplicantId)
                    .HasColumnName("PK_ApplicantId")
                    .HasMaxLength(128);

                entity.HasMany(e => e.Application).WithOne(e => e.Applicants).HasForeignKey(e => e.ApplicantId).IsRequired(false);

            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasKey(e => e.PkApplicationId);

                entity.Property(e => e.PkApplicationId)
                    .HasColumnName("PK_ApplicationId")
                    .HasMaxLength(128);

                entity.HasOne(e => e.SponsorOrHost).WithOne(e => e.Application).HasForeignKey<SponsorOrHost>(e => e.ApplicationId).IsRequired();

                entity.HasMany(e => e.ApplicationDocument).WithOne(e => e.Application).HasForeignKey("ApplicationId").IsRequired();
                entity.HasMany(e => e.ApplicationStatus).WithOne(e => e.Application).HasForeignKey("ApplicationId").IsRequired();

            });

            modelBuilder.Entity<ApplicationDocument>(entity =>
            {
                entity.HasKey(e => e.PkDocumentId);

                entity.Property(e => e.PkDocumentId)
                    .HasColumnName("PK_DocumentId")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<ApplicationStatus>(entity =>
            {
                entity.HasKey(e => e.PkStatusId);

                entity.Property(e => e.PkStatusId)
                    .HasColumnName("PK_StatusId")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<SponsorOrHost>(entity =>
            {
                entity.HasKey(e => e.PkId);

                entity.Property(e => e.PkId)
                    .HasColumnName("PK_Id")
                    .HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
