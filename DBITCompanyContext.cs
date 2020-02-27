using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IT_Companies
{
    public partial class DBITCompanyContext : DbContext
    {
        public DBITCompanyContext()
        {
        }

        public DBITCompanyContext(DbContextOptions<DBITCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<EmpSubs> EmpSubs { get; set; }
        public virtual DbSet<Employers> Employers { get; set; }
        public virtual DbSet<ItCompanies> ItCompanies { get; set; }
        public virtual DbSet<Offices> Offices { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Subdivisions> Subdivisions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-G05H9NK\\SQLEXPRESS; Database=DBITCompany; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryId).HasColumnName("Country_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Countries");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmpSubs>(entity =>
            {
                entity.ToTable("Emp_Subs");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployerId).HasColumnName("Employer_id");

                entity.Property(e => e.PositionId).HasColumnName("Position_id");

                entity.Property(e => e.SubdivisionId).HasColumnName("Subdivision_id");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.EmpSubs)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emp_Subs_Employers");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.EmpSubs)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emp_Subs_Positions");

                entity.HasOne(d => d.Subdivision)
                    .WithMany(p => p.EmpSubs)
                    .HasForeignKey(d => d.SubdivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emp_Subs_Subdivisions");
            });

            modelBuilder.Entity<Employers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Education)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ItCompanies>(entity =>
            {
                entity.ToTable("IT_Companies");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Offices>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.ItCompanyId).HasColumnName("IT_Company_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Offices)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offices_Cities");

                entity.HasOne(d => d.ItCompany)
                    .WithMany(p => p.Offices)
                    .HasForeignKey(d => d.ItCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Offices_IT_Companies");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItCompanyId).HasColumnName("IT_Company_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ItCompany)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ItCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_IT_Companies");
            });

            modelBuilder.Entity<Subdivisions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OfficeId).HasColumnName("Office_id");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Subdivisions)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subdivisions_Offices");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
