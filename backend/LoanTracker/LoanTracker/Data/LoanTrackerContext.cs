using System;
using System.Collections.Generic;
using LoanTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanTracker.Data;

public partial class LoanTrackerContext : DbContext
{
    public LoanTrackerContext(DbContextOptions<LoanTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<LoanApplication> LoanApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customers_pkey");

            entity.ToTable("customers");

            entity.HasIndex(e => e.Nik, "customers_nik_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Income)
                .HasPrecision(15, 2)
                .HasColumnName("income");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Nik)
                .HasMaxLength(16)
                .HasColumnName("nik");
        });

        modelBuilder.Entity<LoanApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("loan_applications_pkey");

            entity.ToTable("loan_applications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(15, 2)
                .HasColumnName("amount");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.InterestRatePercent)
                .HasPrecision(5, 2)
                .HasColumnName("interest_rate_percent");
            entity.Property(e => e.TenorMonths).HasColumnName("tenor_months");

            entity.HasOne(d => d.Customer).WithMany(p => p.LoanApplications)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("loan_applications_customer_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
