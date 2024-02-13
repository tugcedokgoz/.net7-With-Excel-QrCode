using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExcelQrProject.Model.Models;

public partial class ExcelQrProjectContext : DbContext
{
    public ExcelQrProjectContext()
    {
    }

    public ExcelQrProjectContext(DbContextOptions<ExcelQrProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-R04PVQ3\\SQLEXPRESS; Initial Catalog=ExcelQrProject; Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.QrcodePath).HasColumnName("QRCodePath");
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
