using Microsoft.EntityFrameworkCore;

namespace PatientManagement.Models;

public partial class PatientContext : DbContext
{
    public PatientContext()
    {
    }

    public PatientContext(DbContextOptions<PatientContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Detail> Details { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=Patient;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Admin");

            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Detail>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Detail__970EC366E89AF61A");

            entity.ToTable("Detail");

            entity.Property(e => e.Address)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Address_");
            entity.Property(e => e.AdmittedDate).HasColumnName("Admitted_Date");
            entity.Property(e => e.DischargedDate).HasColumnName("Discharged_Date");
            entity.Property(e => e.MblNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Mbl_No");
            entity.Property(e => e.MedicalTest)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Medical_Test");
            entity.Property(e => e.PatientName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Symptoms)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
