using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FarmerSchemeProjectNew.Models
{
    public partial class DbfarmerContext : DbContext
    {
        public DbfarmerContext()
        {
        }

        public DbfarmerContext(DbContextOptions<DbfarmerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankDetail> BankDetails { get; set; }
        public virtual DbSet<Bidding> Biddings { get; set; }
        public virtual DbSet<ClaimInsurance> ClaimInsurances { get; set; }
        public virtual DbSet<CropTable> CropTables { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<LandDetail> LandDetails { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Roletable> Roletables { get; set; }
        public virtual DbSet<SellCrop> SellCrops { get; set; }
        public virtual DbSet<SoldHistory> SoldHistories { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-UL9E6NOK\\SQLEXPRESS;Database=Dbfarmer;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BankDetail>(entity =>
            {
                entity.HasKey(e => e.AccountNo)
                    .HasName("PK__BankDeta__349D9DFDB128CA77");

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.Property(e => e.Ifsccode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IFSCCode");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.BankDetails)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BankDetai__Email__3E52440B");
            });

            modelBuilder.Entity<Bidding>(entity =>
            {
                entity.HasKey(e => e.BidderId)
                    .HasName("PK__Bidding__3D8E533940E979B5");

                entity.ToTable("Bidding");

                entity.Property(e => e.BidderId).HasColumnName("BidderID");

                entity.Property(e => e.BiddingDate).HasColumnType("date");

                entity.Property(e => e.SellId).HasColumnName("SellID");

                entity.HasOne(d => d.Sell)
                    .WithMany(p => p.Biddings)
                    .HasForeignKey(d => d.SellId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bidding__SellID__4CA06362");
            });

            modelBuilder.Entity<ClaimInsurance>(entity =>
            {
                entity.HasKey(e => e.PolicyNo)
                    .HasName("PK__ClaimIns__2E132197F5F158AA");

                entity.ToTable("ClaimInsurance");

                entity.Property(e => e.CauseofLoss)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfLoss).HasColumnType("date");

                entity.Property(e => e.NameofInsure)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CropTable>(entity =>
            {
                entity.HasKey(e => e.CropId)
                    .HasName("PK__CropTabl__92356135A07AF57A");

                entity.ToTable("CropTable");

                entity.Property(e => e.CropId).HasColumnName("CropID");

                entity.Property(e => e.CropName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CropType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerId).HasColumnName("FarmerID");

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.CropTables)
                    .HasForeignKey(d => d.FarmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CropTable__Farme__49C3F6B7");
            });

            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.ToTable("Insurance");

                entity.Property(e => e.InsuranceId).HasColumnName("InsuranceID");

                entity.Property(e => e.Area).HasColumnType("text");

                entity.Property(e => e.CropName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsuranceCompany)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Season)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Year)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.PolicyNoNavigation)
                    .WithMany(p => p.Insurances)
                    .HasForeignKey(d => d.PolicyNo)
                    .HasConstraintName("FK__Insurance__Polic__5629CD9C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Insurances)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Insurance__UserI__5535A963");
            });

            modelBuilder.Entity<LandDetail>(entity =>
            {
                entity.HasKey(e => e.FarmerId)
                    .HasName("PK__LandDeta__731B88E84D786CEE");

                entity.Property(e => e.FarmerId).HasColumnName("FarmerID");

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.Area).HasColumnType("text");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.LandDetails)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LandDetai__Email__412EB0B6");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__Registra__7ED91AEF6A638C8D");

                entity.ToTable("Registration");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.Property(e => e.Aadhaar)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine1).HasColumnType("text");

                entity.Property(e => e.AddressLine2).HasColumnType("text");

                entity.Property(e => e.Certificate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConformPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PAN");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roletable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Roletabl__1788CCACBA20FE1F");

                entity.ToTable("Roletable");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ApprovedStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.Property(e => e.RoleType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.Roletables)
                    .HasForeignKey(d => d.EmailId)
                    .HasConstraintName("FK__Roletable__Email__3B75D760");
            });

            modelBuilder.Entity<SellCrop>(entity =>
            {
                entity.HasKey(e => e.SellId)
                    .HasName("PK__SellCrop__B35F66FFDC98DA9D");

                entity.ToTable("SellCrop");

                entity.Property(e => e.SellId).HasColumnName("SellID");

                entity.Property(e => e.CropName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CropType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FarmerId).HasColumnName("FarmerID");

                entity.Property(e => e.FertilizerType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SoilPhcertificate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SoilPHCertificate");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.SellCrops)
                    .HasForeignKey(d => d.FarmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SellCrop__Farmer__440B1D61");
            });

            modelBuilder.Entity<SoldHistory>(entity =>
            {
                entity.HasKey(e => e.Date)
                    .HasName("PK__SoldHist__77387D066DF4260E");

                entity.ToTable("SoldHistory");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.CropName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Msp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MSP");

                entity.Property(e => e.SellId).HasColumnName("SellID");

                entity.HasOne(d => d.Sell)
                    .WithMany(p => p.SoldHistories)
                    .HasForeignKey(d => d.SellId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SoldHisto__SellI__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
