using System;
using System.Collections.Generic;
using HDD.ApplicationCore.Entities;
using HDD.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HDD.Infrastructure.Data
{
    public partial class HDDDbContext : ApplicationDbContext
    {
        public HDDDbContext(DbContextOptions<HDDDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Dmvccddata> Dmvccddata { get; set; } = null!;
        public virtual DbSet<OwnersVin> OwnersVins { get; set; } = null!;
        public virtual DbSet<RetrofitApplication> RetrofitApplications { get; set; } = null!;
        public virtual DbSet<RetrofitCertification> RetrofitCertifications { get; set; } = null!;
        public virtual DbSet<SecondaryOwnerAssignment> SecondaryOwnerAssignments { get; set; } = null!;
        public virtual DbSet<ValidCertificationYear> ValidCertificationYears { get; set; } = null!;
        public virtual DbSet<ValidCertifiedType> ValidCertifiedTypes { get; set; } = null!;
        public virtual DbSet<ValidDocumentType> ValidDocumentTypes { get; set; } = null!;
        public virtual DbSet<ValidRetrofitProvider> ValidRetrofitProviders { get; set; } = null!;
        public virtual DbSet<ValidRetrofitType> ValidRetrofitTypes { get; set; } = null!;
        public virtual DbSet<ValidStatusType> ValidStatusTypes { get; set; } = null!;
        public virtual DbSet<VehicleDocument> VehicleDocuments { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=deqsql2\\dev;UID=HDDUser;PWD=LM(6k%,,+z?);Database=HDD;MultipleActiveResultSets=true;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
//            modelBuilder.Entity<AspNetRole>(entity =>
//            {
//                entity.Property(e => e.Name).HasMaxLength(256);

//                entity.Property(e => e.NormalizedName).HasMaxLength(256);
//            });

//            modelBuilder.Entity<AspNetRoleClaim>(entity =>
//            {
//                entity.Property(e => e.RoleId).HasMaxLength(450);

//                entity.HasOne(d => d.Role)
//                    .WithMany(p => p.AspNetRoleClaims)
//                    .HasForeignKey(d => d.RoleId);
//            });

//            modelBuilder.Entity<AspNetUser>(entity =>
//            {
//                entity.ToTable(tb => tb.IsTemporal(ttb =>
//    {
//        ttb.UseHistoryTable("aspnetusersHistory", "dbo");
//        ttb
//            .HasPeriodStart("ValidFrom")
//            .HasColumnName("ValidFrom");
//        ttb
//            .HasPeriodEnd("ValidTo")
//            .HasColumnName("ValidTo");
//    }
//));

//                entity.Property(e => e.Company).HasMaxLength(100);

//                entity.Property(e => e.Email).HasMaxLength(256);

//                entity.Property(e => e.FirstName).HasMaxLength(250);

//                entity.Property(e => e.LastName).HasMaxLength(250);

//                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

//                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

//                entity.Property(e => e.Plate).HasMaxLength(10);

//                entity.Property(e => e.RegisteredZip).HasMaxLength(10);

//                entity.Property(e => e.Title).HasMaxLength(100);

//                entity.Property(e => e.UserName).HasMaxLength(256);

//                entity.Property(e => e.Vin)
//                    .HasMaxLength(20)
//                    .HasColumnName("VIN");

//                entity.HasMany(d => d.Roles)
//                    .WithMany(p => p.Users)
//                    .UsingEntity<Dictionary<string, object>>(
//                        "AspNetUserRole",
//                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
//                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
//                        j =>
//                        {
//                            j.HasKey("UserId", "RoleId");

//                            j.ToTable("AspNetUserRoles");
//                        });
//            });

//            modelBuilder.Entity<AspNetUserClaim>(entity =>
//            {
//                entity.Property(e => e.UserId).HasMaxLength(450);

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.AspNetUserClaims)
//                    .HasForeignKey(d => d.UserId);
//            });

//            modelBuilder.Entity<AspNetUserLogin>(entity =>
//            {
//                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

//                entity.Property(e => e.LoginProvider).HasMaxLength(128);

//                entity.Property(e => e.ProviderKey).HasMaxLength(128);

//                entity.Property(e => e.UserId).HasMaxLength(450);

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.AspNetUserLogins)
//                    .HasForeignKey(d => d.UserId);
//            });

//            modelBuilder.Entity<AspNetUserToken>(entity =>
//            {
//                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

//                entity.Property(e => e.LoginProvider).HasMaxLength(128);

//                entity.Property(e => e.Name).HasMaxLength(128);

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.AspNetUserTokens)
//                    .HasForeignKey(d => d.UserId);
//            });

            modelBuilder.Entity<Dmvccddata>(entity =>
            {
                entity.HasKey(e => e.Vin)
                    .HasName("PK_DMVData");

                entity.ToTable("DMVCCDData");

                entity.Property(e => e.Vin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                entity.Property(e => e.ChangedOwnership)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.County)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDateTime).HasColumnType("datetime");

                entity.Property(e => e.Gvw).HasColumnName("GVW");

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Plate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PubliclyOwned)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegistrationExpiration)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RenewalAgency)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RunDate).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.WeightRange)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ZIP");
            });
            modelBuilder.Entity<Dmvccddata>(entity =>
            {
                entity.HasKey(e => e.Vin)
                    .HasName("PK_DMVData");

                entity.ToTable("DMVCCDData");

                entity.Property(e => e.Vin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                entity.Property(e => e.ChangedOwnership)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.County)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDateTime).HasColumnType("datetime");

                entity.Property(e => e.Gvw).HasColumnName("GVW");

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Plate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PubliclyOwned)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegistrationExpiration)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RenewalAgency)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RunDate).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.WeightRange)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ZIP");
            });

            modelBuilder.Entity<OwnersVin>(entity =>
            {
                entity.ToTable("OwnersVIN");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("OwnersVINHistory", "dbo");
        ttb
            .HasPeriodStart("ValidFrom")
            .HasColumnName("ValidFrom");
        ttb
            .HasPeriodEnd("ValidTo")
            .HasColumnName("ValidTo");
    }
));

                entity.HasIndex(e => new { e.OwnerId, e.Vin }, "UK_OwnersVIN")
                    .IsUnique();

                entity.Property(e => e.OwnersVinid).HasColumnName("OwnersVINId");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.Property(e => e.Vin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                //entity.HasOne(d => d.Owner)
                //    .WithMany(p => p.OwnersVins)
                //    .HasForeignKey(d => d.OwnerId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_OwnersVIN_AspNetUsers");

                entity.HasOne(d => d.VinNavigation)
                    .WithMany(p => p.OwnersVins)
                    .HasForeignKey(d => d.Vin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OwnersVIN_DMVCCDData");
            });

            modelBuilder.Entity<RetrofitApplication>(entity =>
            {
                entity.HasKey(e => e.Vin);

                entity.ToTable("RetrofitApplication");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("RetrofitApplicationHistory", "dbo");
        ttb
            .HasPeriodStart("ValidFrom")
            .HasColumnName("ValidFrom");
        ttb
            .HasPeriodEnd("ValidTo")
            .HasColumnName("ValidTo");
    }
));

                entity.Property(e => e.Vin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                entity.Property(e => e.ApplicationDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ArtFamilyName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ART_FamilyName");

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EngineDisplacement)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.EngineFamilyNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EngineManufacturer)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(450);

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.RetrofitProvider)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RetrofitType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RunDate).HasColumnType("datetime");

                //entity.HasOne(d => d.LastUpdatedByNavigation)
                //    .WithMany(p => p.RetrofitApplications)
                //    .HasForeignKey(d => d.LastUpdatedBy)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_RetrofitApplication_AspNetUsers");

                entity.HasOne(d => d.RetrofitProviderNavigation)
                    .WithMany(p => p.RetrofitApplications)
                    .HasForeignKey(d => d.RetrofitProvider)
                    .HasConstraintName("FK_RetrofitApplication_ValidRetrofitProviders");

                entity.HasOne(d => d.RetrofitTypeNavigation)
                    .WithMany(p => p.RetrofitApplications)
                    .HasForeignKey(d => d.RetrofitType)
                    .HasConstraintName("FK_RetrofitApplication_ValidRetrofitTypes");

                entity.HasOne(d => d.VinNavigation)
                    .WithOne(p => p.RetrofitApplication)
                    .HasForeignKey<RetrofitApplication>(d => d.Vin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RetrofitApplication_DMVCCDData");
            });

            modelBuilder.Entity<RetrofitCertification>(entity =>
            {
                entity.HasKey(e => e.Vin);

                entity.ToTable("RetrofitCertification");

                entity.Property(e => e.Vin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                entity.Property(e => e.ActionDate).HasColumnType("datetime");

                entity.Property(e => e.ActionInspectorId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ActionInspectorID");

                entity.Property(e => e.AgencyChanged)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Certified)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Comments)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EntryDateTime).HasColumnType("datetime");

                entity.Property(e => e.EntryUserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EntryUserID");

                entity.Property(e => e.Vinstatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("VINStatus")
                    .IsFixedLength();

                entity.HasOne(d => d.CertifiedNavigation)
                    .WithMany(p => p.RetrofitCertifications)
                    .HasForeignKey(d => d.Certified)
                    .HasConstraintName("FK_RetrofitCertification_ValidCertifiedTypes");

                entity.HasOne(d => d.VinNavigation)
                    .WithOne(p => p.RetrofitCertification)
                    .HasForeignKey<RetrofitCertification>(d => d.Vin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RetrofitCertification_DMVCCDData");

                entity.HasOne(d => d.VinstatusNavigation)
                    .WithMany(p => p.RetrofitCertifications)
                    .HasForeignKey(d => d.Vinstatus)
                    .HasConstraintName("FK_RetrofitCertification_ValidStatusTypes");
            });

            modelBuilder.Entity<SecondaryOwnerAssignment>(entity =>
            {
                entity.HasKey(e => e.SecondaryOwnerAssignmentId);
                entity.ToTable("SecondaryOwnerAssignment");

                entity.HasIndex(e => new { e.OwnerId, e.Vin, e.IncomingSecondaryOwnerEmail }, "UK_SecondaryOwnerAssignment")
                    .IsUnique();

                entity.Property(e => e.AssignedDate).HasColumnType("datetime");

                entity.Property(e => e.IncomingSecondaryOwnerEmail).HasMaxLength(256);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.Vin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                //entity.HasOne(d => d.Owner)
                //    .WithMany(p => p.SecondaryOwnerAssignments)
                //    .HasForeignKey(d => d.OwnerId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_SecondaryOwnerAssignment_AspNetUsers");

                entity.HasOne(d => d.VinNavigation)
                    .WithMany(p => p.SecondaryOwnerAssignments)
                    .HasForeignKey(d => d.Vin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SecondaryOwnerAssignment_DMVCCDData");
            });

            modelBuilder.Entity<ValidCertificationYear>(entity =>
            {
                entity.HasKey(e => e.CertificationYear);

                entity.Property(e => e.CertificationYear).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ValidCertifiedType>(entity =>
            {
                entity.HasKey(e => e.CertifiedType);

                entity.Property(e => e.CertifiedType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ValidDocumentType>(entity =>
            {
                entity.HasKey(e => e.DocumentTypeId);

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ValidRetrofitProvider>(entity =>
            {
                entity.HasKey(e => e.RetrofitProvoder);

                entity.Property(e => e.RetrofitProvoder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ValidRetrofitType>(entity =>
            {
                entity.HasKey(e => e.RetrofitType);

                entity.Property(e => e.RetrofitType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ValidStatusType>(entity =>
            {
                entity.HasKey(e => e.StatusType);

                entity.Property(e => e.StatusType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehicleDocument>(entity =>
            {
                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("VehicleDocumentsHistory", "dbo");
        ttb
            .HasPeriodStart("ValidFrom")
            .HasColumnName("ValidFrom");
        ttb
            .HasPeriodEnd("ValidTo")
            .HasColumnName("ValidTo");
    }
));

                entity.HasIndex(e => new { e.Vin, e.DocumentTypeId, e.CertificationYear, e.UploadedBy, e.UploadedDate }, "UK_VehicleDocuments")
                    .IsUnique();

                entity.Property(e => e.DeleteRequestedBy).HasMaxLength(450);

                entity.Property(e => e.DeleteRequestedDate).HasColumnType("datetime");

                entity.Property(e => e.DocumentName).HasMaxLength(100);

                entity.Property(e => e.UploadedDate).HasColumnType("datetime");

                entity.Property(e => e.Vin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                entity.HasOne(d => d.CertificationYearNavigation)
                    .WithMany(p => p.VehicleDocuments)
                    .HasForeignKey(d => d.CertificationYear)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleDocuments_ValidCertificationYears");

                //entity.HasOne(d => d.DeleteRequestedByNavigation)
                //    .WithMany(p => p.VehicleDocumentDeleteRequestedByNavigations)
                //    .HasForeignKey(d => d.DeleteRequestedBy)
                //    .HasConstraintName("FK_VehicleDocuments_AspNetUsers2");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.VehicleDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleDocuments_ValidDocumentTypes");

                //entity.HasOne(d => d.UploadedByNavigation)
                //    .WithMany(p => p.VehicleDocumentUploadedByNavigations)
                //    .HasForeignKey(d => d.UploadedBy)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_VehicleDocuments_AspNetUsers1");

                entity.HasOne(d => d.VinNavigation)
                    .WithMany(p => p.VehicleDocuments)
                    .HasForeignKey(d => d.Vin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleDocuments_RetrofitApplication");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
