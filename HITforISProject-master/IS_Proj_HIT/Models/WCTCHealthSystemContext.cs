using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IS_Proj_HIT.Models
{
    public partial class WCTCHealthSystemContext : DbContext
    {
        public WCTCHealthSystemContext()
        {
        }

        public WCTCHealthSystemContext(DbContextOptions<WCTCHealthSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AdmitType> AdmitType { get; set; }
        public virtual DbSet<AdvancedDirectives> AdvancedDirectives { get; set; }
        public virtual DbSet<AlertType> AlertType { get; set; }
        public virtual DbSet<Allergen> Allergen { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CareSystemAssessment> CareSystemAssessment { get; set; }
        public virtual DbSet<CareSystemAssessmentType> CareSystemAssessmentType { get; set; }
        public virtual DbSet<ClinicalReminders> ClinicalReminders { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Discharge> Discharge { get; set; }
        public virtual DbSet<Employment> Employment { get; set; }
        public virtual DbSet<Encounter> Encounter { get; set; }
        public virtual DbSet<EncounterAlerts> EncounterAlerts { get; set; }
        public virtual DbSet<EncounterPhysicians> EncounterPhysicians { get; set; }
        public virtual DbSet<EncounterType> EncounterType { get; set; }
        public virtual DbSet<Ethnicity> Ethnicity { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<FallRisks> FallRisks { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Insurance> Insurance { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<O2deliveryType> O2deliveryType { get; set; }
        public virtual DbSet<PainScaleType> PainScaleType { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientAdvancedDirectives> PatientAdvancedDirectives { get; set; }
        public virtual DbSet<PatientAlerts> PatientAlerts { get; set; }
        public virtual DbSet<PatientAllergy> PatientAllergy { get; set; }
        public virtual DbSet<PatientClinicalReminders> PatientClinicalReminders { get; set; }
        public virtual DbSet<PatientContactDetails> PatientContactDetails { get; set; }
        public virtual DbSet<PatientEmergencyContact> PatientEmergencyContact { get; set; }
        public virtual DbSet<PatientFallRisks> PatientFallRisks { get; set; }
        public virtual DbSet<PatientLanguage> PatientLanguage { get; set; }
        public virtual DbSet<PatientMilitaryService> PatientMilitaryService { get; set; }
        public virtual DbSet<PatientRace> PatientRace { get; set; }
        public virtual DbSet<PatientRestrictions> PatientRestrictions { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentPlan> PaymentPlan { get; set; }
        public virtual DbSet<PaymentSource> PaymentSource { get; set; }
        public virtual DbSet<Pcacomment> Pcacomment { get; set; }
        public virtual DbSet<PcacommentType> PcacommentType { get; set; }
        public virtual DbSet<Pcarecord> Pcarecord { get; set; }
        public virtual DbSet<Physician> Physician { get; set; }
        public virtual DbSet<PhysicianRole> PhysicianRole { get; set; }
        public virtual DbSet<PlaceOfServiceOutPatient> PlaceOfServiceOutPatient { get; set; }
        public virtual DbSet<PointOfOrigin> PointOfOrigin { get; set; }
        public virtual DbSet<PreferredContactTime> PreferredContactTime { get; set; }
        public virtual DbSet<PreferredModeOfContact> PreferredModeOfContact { get; set; }
        public virtual DbSet<ProviderType> ProviderType { get; set; }
        public virtual DbSet<PulseRouteType> PulseRouteType { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<Reaction> Reaction { get; set; }
        public virtual DbSet<Relationship> Relationship { get; set; }
        public virtual DbSet<Religion> Religion { get; set; }
        public virtual DbSet<Restrictions> Restrictions { get; set; }
        public virtual DbSet<Sex> Sex { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<TempRouteType> TempRouteType { get; set; }
        public virtual DbSet<UserFacility> UserFacility { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=bitsql.wctc.edu;Database=WCTCHealthSystem;User ID=HealthSystemApp;Password=WCTC_H3alth;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Address_CountryID");
            });

            modelBuilder.Entity<AdmitType>(entity =>
            {
                entity.Property(e => e.AdmitTypeId).HasColumnName("AdmitTypeID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Explaination).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WiPopCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdvancedDirectives>(entity =>
            {
                entity.HasKey(e => e.AdvancedDirectiveId)
                    .HasName("pk_AdvancedDirectives");

                entity.Property(e => e.AdvancedDirectiveId).HasColumnName("AdvancedDirectiveID");
            });

            modelBuilder.Entity<AlertType>(entity =>
            {
                entity.HasKey(e => e.AlertId);

                entity.Property(e => e.AlertId).HasColumnName("AlertID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Allergen>(entity =>
            {
                entity.Property(e => e.AllergenId).HasColumnName("AllergenID");

                entity.Property(e => e.AllergenName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CareSystemAssessment>(entity =>
            {
                entity.HasKey(e => new { e.CareSystemAssessmentId, e.Pcaid });

                entity.Property(e => e.CareSystemAssessmentId)
                    .HasColumnName("CareSystemAssessmentID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Pcaid).HasColumnName("PCAID");

                entity.Property(e => e.CareSystemAssessmentTypeId).HasColumnName("CareSystemAssessmentTypeID");

                entity.Property(e => e.CareSystemComment).IsUnicode(false);

                entity.Property(e => e.DateCareSystemAdded).HasColumnType("datetime");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WdlEx).HasColumnName("WDL_EX");

                entity.HasOne(d => d.CareSystemAssessmentType)
                    .WithMany(p => p.CareSystemAssessment)
                    .HasForeignKey(d => d.CareSystemAssessmentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CareSystemAssessment_CareSystemAssessmentTypeID");

                entity.HasOne(d => d.Pca)
                    .WithMany(p => p.CareSystemAssessment)
                    .HasForeignKey(d => d.Pcaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CareSystemAssessment_PCAID");
            });

            modelBuilder.Entity<CareSystemAssessmentType>(entity =>
            {
                entity.Property(e => e.CareSystemAssessmentTypeId).HasColumnName("CareSystemAssessmentTypeID");

                entity.Property(e => e.CareSystemAssessmentTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ClinicalReminders>(entity =>
            {
                entity.HasKey(e => e.ClinicalReminderId)
                    .HasName("pk_ClinicalReminder");

                entity.Property(e => e.ClinicalReminderId).HasColumnName("ClinicalReminderID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Discharge>(entity =>
            {
                entity.Property(e => e.DischargeId).HasColumnName("DischargeID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.WiPopCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employment>(entity =>
            {
                entity.Property(e => e.EmploymentId).HasColumnName("EmploymentID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Occupation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Encounter>(entity =>
            {
                entity.Property(e => e.EncounterId).HasColumnName("EncounterID");

                entity.Property(e => e.AdmitDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AdmitTypeId).HasColumnName("AdmitTypeID");

                entity.Property(e => e.ChiefComplaint)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DischargeDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EncounterPhysiciansId).HasColumnName("EncounterPhysiciansID");

                entity.Property(e => e.EncounterRestrictionId).HasColumnName("EncounterRestrictionID");

                entity.Property(e => e.EncounterTypeId).HasColumnName("EncounterTypeID");

                entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mrn)
                    .IsRequired()
                    .HasColumnName("MRN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.PlaceOfServiceId).HasColumnName("PlaceOfServiceID");

                entity.Property(e => e.PointOfOriginId).HasColumnName("PointOfOriginID");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.AdmitType)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.AdmitTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Encounter_AdmitTypeID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("fk_Encounter_DepartmentID");

                entity.HasOne(d => d.DischargeDispositionNavigation)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.DischargeDisposition)
                    .HasConstraintName("fk_Encounter_DischargeDisposition");

                entity.HasOne(d => d.EncounterPhysicians)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.EncounterPhysiciansId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Encounter_EncounterPhysiciansID");

                entity.HasOne(d => d.EncounterType)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.EncounterTypeId)
                    .HasConstraintName("fk_Encounter_EncounterTypeID");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Encounter_FacilityID");

                entity.HasOne(d => d.MrnNavigation)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.Mrn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Encounter_MRN");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("fk_Encounter_PaymentID");

                entity.HasOne(d => d.PlaceOfService)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.PlaceOfServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Encounter_PlaceOfServiceID");

                entity.HasOne(d => d.PointOfOrigin)
                    .WithMany(p => p.Encounter)
                    .HasForeignKey(d => d.PointOfOriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Encounter_PointOfOriginID");
            });

            modelBuilder.Entity<EncounterAlerts>(entity =>
            {
                entity.HasKey(e => new { e.EncounterId, e.PatientAlertId });

                entity.Property(e => e.EncounterId).HasColumnName("EncounterID");

                entity.Property(e => e.PatientAlertId).HasColumnName("PatientAlertID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Encounter)
                    .WithMany(p => p.EncounterAlerts)
                    .HasForeignKey(d => d.EncounterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EncounterAlerts_EncounterID");

                entity.HasOne(d => d.PatientAlert)
                    .WithMany(p => p.EncounterAlerts)
                    .HasForeignKey(d => d.PatientAlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EncounterAlerts_PatientAlertID");
            });

            modelBuilder.Entity<EncounterPhysicians>(entity =>
            {
                entity.Property(e => e.EncounterPhysiciansId).HasColumnName("EncounterPhysiciansID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PhysicianId).HasColumnName("PhysicianID");

                entity.Property(e => e.PhysicianRoleId).HasColumnName("PhysicianRoleID");

                entity.HasOne(d => d.Physician)
                    .WithMany(p => p.EncounterPhysicians)
                    .HasForeignKey(d => d.PhysicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EncounterPhysicians_PhysicianID");

                entity.HasOne(d => d.PhysicianRole)
                    .WithMany(p => p.EncounterPhysicians)
                    .HasForeignKey(d => d.PhysicianRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EncounterPhysicians_PhysicianRoleID");
            });

            modelBuilder.Entity<EncounterType>(entity =>
            {
                entity.Property(e => e.EncounterTypeId).HasColumnName("EncounterTypeID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ethnicity>(entity =>
            {
                entity.Property(e => e.EthnicityId)
                    .HasColumnName("EthnicityID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Facility)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Facility_AddressID");
            });

            modelBuilder.Entity<FallRisks>(entity =>
            {
                entity.HasKey(e => e.FallRiskId)
                    .HasName("pk_FallRisks");

                entity.Property(e => e.FallRiskId)
                    .HasColumnName("FallRiskID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.GenderId)
                    .HasColumnName("GenderID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.Property(e => e.InsuranceId).HasColumnName("InsuranceID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Fax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GroupName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsuranceName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentPlanId).HasColumnName("PaymentPlanID");

                entity.Property(e => e.PaymentSourceId).HasColumnName("PaymentSourceID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Subscriber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Insurance)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Insurance_AddressID");

                entity.HasOne(d => d.PaymentPlan)
                    .WithMany(p => p.Insurance)
                    .HasForeignKey(d => d.PaymentPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Insurance_PaymentPlanID");

                entity.HasOne(d => d.PaymentSource)
                    .WithMany(p => p.Insurance)
                    .HasForeignKey(d => d.PaymentSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Insurance_PaymentSourceID");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.Property(e => e.MaritalStatusId)
                    .HasColumnName("MaritalStatusID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<O2deliveryType>(entity =>
            {
                entity.ToTable("O2DeliveryType");

                entity.Property(e => e.O2deliveryTypeId).HasColumnName("O2DeliveryTypeID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.O2deliveryTypeName)
                    .IsRequired()
                    .HasColumnName("O2DeliveryTypeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PainScaleType>(entity =>
            {
                entity.Property(e => e.PainScaleTypeId).HasColumnName("PainScaleTypeID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PainScaleTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Mrn);

                entity.Property(e => e.Mrn)
                    .HasColumnName("MRN")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AliasFirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AliasLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AliasMiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EmploymentId).HasColumnName("EmploymentID");

                entity.Property(e => e.EthnicityId).HasColumnName("EthnicityID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaidenName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MothersMaidenName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReligionId).HasColumnName("ReligionID");

                entity.Property(e => e.SexId).HasColumnName("SexID");

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasColumnName("SSN")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employment)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.EmploymentId)
                    .HasConstraintName("fk_Patient_EmploymentID");

                entity.HasOne(d => d.Ethnicity)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.EthnicityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Patient_EthnicityID");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("fk_Patient_GenderID");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Patient_MaritalStatusID");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.ReligionId)
                    .HasConstraintName("fk_Patient_ReligionID");

                entity.HasOne(d => d.Sex)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.SexId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Patient_SexID");
            });

            modelBuilder.Entity<PatientAdvancedDirectives>(entity =>
            {
                entity.HasKey(e => e.PatientAdvancedDirectiveId)
                    .HasName("pk_PatientAdvancedDirectives");

                entity.Property(e => e.PatientAdvancedDirectiveId).HasColumnName("PatientAdvancedDirectiveID");

                entity.Property(e => e.AdvancedDirectiveId).HasColumnName("AdvancedDirectiveID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PatientAlertId).HasColumnName("PatientAlertID");

                entity.HasOne(d => d.AdvancedDirective)
                    .WithMany(p => p.PatientAdvancedDirectives)
                    .HasForeignKey(d => d.AdvancedDirectiveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientAdvancedDirectives_AdvancedDirectiveID");

                entity.HasOne(d => d.PatientAlert)
                    .WithMany(p => p.PatientAdvancedDirectives)
                    .HasForeignKey(d => d.PatientAlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientAdvancedDirectives_PatientAlertID");
            });

            modelBuilder.Entity<PatientAlerts>(entity =>
            {
                entity.HasKey(e => e.PatientAlertId);

                entity.Property(e => e.PatientAlertId).HasColumnName("PatientAlertID");

                entity.Property(e => e.AlertTypeId).HasColumnName("AlertTypeID");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mrn)
                    .IsRequired()
                    .HasColumnName("MRN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AlertType)
                    .WithMany(p => p.PatientAlerts)
                    .HasForeignKey(d => d.AlertTypeId)
                    .HasConstraintName("fk_PatientAlerts_AlertTypeID");

                entity.HasOne(d => d.MrnNavigation)
                    .WithMany(p => p.PatientAlerts)
                    .HasForeignKey(d => d.Mrn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientAlerts_MRN");
            });

            modelBuilder.Entity<PatientAllergy>(entity =>
            {
                entity.Property(e => e.PatientAllergyId).HasColumnName("PatientAllergyID");

                entity.Property(e => e.AllergenId).HasColumnName("AllergenID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PatientAlertId).HasColumnName("PatientAlertID");

                entity.Property(e => e.ReactionId).HasColumnName("ReactionID");

                entity.HasOne(d => d.Allergen)
                    .WithMany(p => p.PatientAllergy)
                    .HasForeignKey(d => d.AllergenId)
                    .HasConstraintName("fk_PatientAllergy_AllergenID");

                entity.HasOne(d => d.PatientAlert)
                    .WithMany(p => p.PatientAllergy)
                    .HasForeignKey(d => d.PatientAlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientAllergy_PatientAlertID");

                entity.HasOne(d => d.Reaction)
                    .WithMany(p => p.PatientAllergy)
                    .HasForeignKey(d => d.ReactionId)
                    .HasConstraintName("fk_PatientAllergy_ReactionID");
            });

            modelBuilder.Entity<PatientClinicalReminders>(entity =>
            {
                entity.HasKey(e => e.PatientClinicalReminderId)
                    .HasName("pk_PatientClinicalReminders");

                entity.Property(e => e.PatientClinicalReminderId).HasColumnName("PatientClinicalReminderID");

                entity.Property(e => e.ClinicalReminderId).HasColumnName("ClinicalReminderID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PatientAlertId).HasColumnName("PatientAlertID");

                entity.HasOne(d => d.ClinicalReminder)
                    .WithMany(p => p.PatientClinicalReminders)
                    .HasForeignKey(d => d.ClinicalReminderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientClinicalReminders_ClinicalReminderID");

                entity.HasOne(d => d.PatientAlert)
                    .WithMany(p => p.PatientClinicalReminders)
                    .HasForeignKey(d => d.PatientAlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientClinicalReminders_PatientAlertID");
            });

            modelBuilder.Entity<PatientContactDetails>(entity =>
            {
                entity.HasKey(e => e.PatientContactId);

                entity.Property(e => e.PatientContactId).HasColumnName("PatientContactID");

                entity.Property(e => e.CellPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MailingAddressId).HasColumnName("MailingAddressID");

                entity.Property(e => e.Mrn)
                    .IsRequired()
                    .HasColumnName("MRN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ResidenceAddressId).HasColumnName("ResidenceAddressID");

                entity.Property(e => e.WorkPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MailingAddress)
                    .WithMany(p => p.PatientContactDetailsMailingAddress)
                    .HasForeignKey(d => d.MailingAddressId)
                    .HasConstraintName("fk_PatientContactDetails_MailingAddressID");

                entity.HasOne(d => d.MrnNavigation)
                    .WithMany(p => p.PatientContactDetails)
                    .HasForeignKey(d => d.Mrn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientContactDetails_MRN");

                entity.HasOne(d => d.PreferredModeOfContactNavigation)
                    .WithMany(p => p.PatientContactDetails)
                    .HasForeignKey(d => d.PreferredModeOfContact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientContactDetails_PreferredModeOfContact");

                entity.HasOne(d => d.PreferredTimeToContactNavigation)
                    .WithMany(p => p.PatientContactDetails)
                    .HasForeignKey(d => d.PreferredTimeToContact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientContactDetails_PreferredTimeToContact");

                entity.HasOne(d => d.ResidenceAddress)
                    .WithMany(p => p.PatientContactDetailsResidenceAddress)
                    .HasForeignKey(d => d.ResidenceAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientContactDetails_ResidenceAddressID");
            });

            modelBuilder.Entity<PatientEmergencyContact>(entity =>
            {
                entity.HasKey(e => e.EmergencyContactId);

                entity.Property(e => e.EmergencyContactId).HasColumnName("EmergencyContactID");

                entity.Property(e => e.ContactAddressId).HasColumnName("ContactAddressID");

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ContactRelationshipId).HasColumnName("ContactRelationshipID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mrn)
                    .IsRequired()
                    .HasColumnName("MRN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.ContactAddress)
                    .WithMany(p => p.PatientEmergencyContact)
                    .HasForeignKey(d => d.ContactAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientEmergencyContact_ContactAddressID");

                entity.HasOne(d => d.ContactRelationship)
                    .WithMany(p => p.PatientEmergencyContact)
                    .HasForeignKey(d => d.ContactRelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientEmergencyContact_ContactRelationshipID");

                entity.HasOne(d => d.MrnNavigation)
                    .WithMany(p => p.PatientEmergencyContact)
                    .HasForeignKey(d => d.Mrn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientEmergencyContact_MRN");
            });

            modelBuilder.Entity<PatientFallRisks>(entity =>
            {
                entity.HasKey(e => e.PatientFallRiskId);

                entity.Property(e => e.PatientFallRiskId).HasColumnName("PatientFallRiskID");

                entity.Property(e => e.FallRiskId).HasColumnName("FallRiskID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PatientAlertId).HasColumnName("PatientAlertID");

                entity.HasOne(d => d.FallRisk)
                    .WithMany(p => p.PatientFallRisks)
                    .HasForeignKey(d => d.FallRiskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientFallRisks_FallRiskID");

                entity.HasOne(d => d.PatientAlert)
                    .WithMany(p => p.PatientFallRisks)
                    .HasForeignKey(d => d.PatientAlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientFallRisks_PatientAlertID");
            });

            modelBuilder.Entity<PatientLanguage>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.Mrn });

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.Mrn)
                    .HasColumnName("MRN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PatientLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientLanguage_LanguageID");

                entity.HasOne(d => d.MrnNavigation)
                    .WithMany(p => p.PatientLanguage)
                    .HasForeignKey(d => d.Mrn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientLanguage_MRN");
            });

            modelBuilder.Entity<PatientMilitaryService>(entity =>
            {
                entity.HasKey(e => e.MilitaryServiceId);

                entity.Property(e => e.MilitaryServiceId).HasColumnName("MilitaryServiceID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Mrn)
                    .IsRequired()
                    .HasColumnName("MRN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.MrnNavigation)
                    .WithMany(p => p.PatientMilitaryService)
                    .HasForeignKey(d => d.Mrn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientMilitaryService_MRN");
            });

            modelBuilder.Entity<PatientRace>(entity =>
            {
                entity.HasKey(e => new { e.RaceId, e.Mrn });

                entity.Property(e => e.RaceId).HasColumnName("RaceID");

                entity.Property(e => e.Mrn)
                    .HasColumnName("MRN")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MrnNavigation)
                    .WithMany(p => p.PatientRace)
                    .HasForeignKey(d => d.Mrn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientRace_MRN");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.PatientRace)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientRace_RaceID");
            });

            modelBuilder.Entity<PatientRestrictions>(entity =>
            {
                entity.HasKey(e => e.RestrictionId);

                entity.Property(e => e.RestrictionId).HasColumnName("RestrictionID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PatientAlertId).HasColumnName("PatientAlertID");

                entity.Property(e => e.RestrictionTypeId).HasColumnName("RestrictionTypeID");

                entity.HasOne(d => d.PatientAlert)
                    .WithMany(p => p.PatientRestrictions)
                    .HasForeignKey(d => d.PatientAlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientRestrictions_PatientAlertID");

                entity.HasOne(d => d.RestrictionType)
                    .WithMany(p => p.PatientRestrictions)
                    .HasForeignKey(d => d.RestrictionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PatientRestrictions_RestrictionID");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PrimaryInsuranceId).HasColumnName("PrimaryInsuranceID");

                entity.Property(e => e.SecondaryInsuranceId).HasColumnName("SecondaryInsuranceID");

                entity.HasOne(d => d.PrimaryInsurance)
                    .WithMany(p => p.PaymentPrimaryInsurance)
                    .HasForeignKey(d => d.PrimaryInsuranceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Insurance_PrimaryInsuranceID");

                entity.HasOne(d => d.SecondaryInsurance)
                    .WithMany(p => p.PaymentSecondaryInsurance)
                    .HasForeignKey(d => d.SecondaryInsuranceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Insurance_SecondaryInsuranceID");
            });

            modelBuilder.Entity<PaymentPlan>(entity =>
            {
                entity.Property(e => e.PaymentPlanId).HasColumnName("PaymentPlanID");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WiPopCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentSource>(entity =>
            {
                entity.Property(e => e.PaymentSourceId).HasColumnName("PaymentSourceID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WiPopCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pcacomment>(entity =>
            {
                entity.ToTable("PCAComment");

                entity.Property(e => e.PcacommentId).HasColumnName("PCACommentID");

                entity.Property(e => e.DateCommentAdded).HasColumnType("datetime");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Pcacomment1)
                    .HasColumnName("PCAComment")
                    .IsUnicode(false);

                entity.Property(e => e.PcacommentTypeId).HasColumnName("PCACommentTypeID");

                entity.Property(e => e.Pcaid).HasColumnName("PCAID");

                entity.HasOne(d => d.PcacommentType)
                    .WithMany(p => p.Pcacomment)
                    .HasForeignKey(d => d.PcacommentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PCAComment_PCACommentTypeID");

                entity.HasOne(d => d.Pca)
                    .WithMany(p => p.Pcacomment)
                    .HasForeignKey(d => d.Pcaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PCAComment_PCAID");
            });

            modelBuilder.Entity<PcacommentType>(entity =>
            {
                entity.ToTable("PCACommentType");

                entity.Property(e => e.PcacommentTypeId).HasColumnName("PCACommentTypeID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PcacommentTypeName)
                    .IsRequired()
                    .HasColumnName("PCACommentTypeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pcarecord>(entity =>
            {
                entity.HasKey(e => e.Pcaid);

                entity.ToTable("PCARecord");

                entity.Property(e => e.Pcaid).HasColumnName("PCAID");

                entity.Property(e => e.DateVitalsAdded).HasColumnType("datetime");

                entity.Property(e => e.EncounterId).HasColumnName("EncounterID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.O2deliveryTypeId).HasColumnName("O2DeliveryTypeID");

                entity.Property(e => e.OxygenFlow)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PainScaleTypeId).HasColumnName("PainScaleTypeID");

                entity.Property(e => e.PulseRouteTypeId).HasColumnName("PulseRouteTypeID");

                entity.Property(e => e.TempRouteTypeId).HasColumnName("TempRouteTypeID");

                entity.Property(e => e.Temperature).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Encounter)
                    .WithMany(p => p.Pcarecord)
                    .HasForeignKey(d => d.EncounterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PCARecord_EncounterID");

                entity.HasOne(d => d.O2deliveryType)
                    .WithMany(p => p.Pcarecord)
                    .HasForeignKey(d => d.O2deliveryTypeId)
                    .HasConstraintName("fk_PCARecord_O2DeliveryTypeID");

                entity.HasOne(d => d.PainScaleType)
                    .WithMany(p => p.Pcarecord)
                    .HasForeignKey(d => d.PainScaleTypeId)
                    .HasConstraintName("fk_PCARecord_PainScaleTypeID");

                entity.HasOne(d => d.PulseRouteType)
                    .WithMany(p => p.Pcarecord)
                    .HasForeignKey(d => d.PulseRouteTypeId)
                    .HasConstraintName("fk_PCARecord_PulseRouteTypeID");

                entity.HasOne(d => d.TempRouteType)
                    .WithMany(p => p.Pcarecord)
                    .HasForeignKey(d => d.TempRouteTypeId)
                    .HasConstraintName("fk_PCARecord_TempRouteTypeID");
            });

            modelBuilder.Entity<Physician>(entity =>
            {
                entity.Property(e => e.PhysicianId).HasColumnName("PhysicianID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Credentials)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.License)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderTypeId).HasColumnName("ProviderTypeID");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Physician)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Physician_AddressID");

                entity.HasOne(d => d.ProviderType)
                    .WithMany(p => p.Physician)
                    .HasForeignKey(d => d.ProviderTypeId)
                    .HasConstraintName("FK_Physician_ProviderTypeID");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.Physician)
                    .HasForeignKey(d => d.SpecialtyId)
                    .HasConstraintName("FK_Physician_SpecialtyID");
            });

            modelBuilder.Entity<PhysicianRole>(entity =>
            {
                entity.Property(e => e.PhysicianRoleId).HasColumnName("PhysicianRoleID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlaceOfServiceOutPatient>(entity =>
            {
                entity.HasKey(e => e.PlaceOfServiceId);

                entity.Property(e => e.PlaceOfServiceId).HasColumnName("PlaceOfServiceID");

                entity.Property(e => e.Description)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PointOfOrigin>(entity =>
            {
                entity.Property(e => e.PointOfOriginId).HasColumnName("PointOfOriginID");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Explaination).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WiPopCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PreferredContactTime>(entity =>
            {
                entity.HasKey(e => e.ContactTimeId);

                entity.Property(e => e.ContactTimeId).HasColumnName("ContactTimeID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PreferredModeOfContact>(entity =>
            {
                entity.HasKey(e => e.ModeOfContactId);

                entity.Property(e => e.ModeOfContactId).HasColumnName("ModeOfContactID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProviderType>(entity =>
            {
                entity.Property(e => e.ProviderTypeId).HasColumnName("ProviderTypeID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PulseRouteType>(entity =>
            {
                entity.Property(e => e.PulseRouteTypeId).HasColumnName("PulseRouteTypeID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PulseRouteTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.Property(e => e.RaceId)
                    .HasColumnName("RaceID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Category)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reaction>(entity =>
            {
                entity.Property(e => e.ReactionId).HasColumnName("ReactionID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Relationship>(entity =>
            {
                entity.Property(e => e.RelationshipId).HasColumnName("RelationshipID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Religion>(entity =>
            {
                entity.Property(e => e.ReligionId).HasColumnName("ReligionID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Restrictions>(entity =>
            {
                entity.HasKey(e => e.RestrictionId)
                    .HasName("pk_Restriction");

                entity.Property(e => e.RestrictionId).HasColumnName("RestrictionID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sex>(entity =>
            {
                entity.Property(e => e.SexId)
                    .HasColumnName("SexID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TempRouteType>(entity =>
            {
                entity.Property(e => e.TempRouteTypeId).HasColumnName("TempRouteTypeID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TempRouteTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserFacility>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FacilityId });

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.UserFacility)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UserFacility_FacilityID");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.UserFacility)
                //    .HasForeignKey(d => d.UserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("fk_UserFacility_UserID");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("UserId")
                    .ValueGeneratedOnAdd();

                entity.HasKey(e => e.UserId)
                    .HasName("PK_User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('12/31/9999')");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Instructor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramEnrolledIn)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AspNetUsersID)
                    .HasMaxLength(400)
                    .IsUnicode(true);
            });

            modelBuilder.HasSequence<int>("MRN_ID");
        }
    }
}
