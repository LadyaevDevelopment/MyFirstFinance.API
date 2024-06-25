using System;
using System.Collections.Generic;
using Data.Production.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Production.Context;

public partial class DefaultDbContext : DbContext
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public DefaultDbContext()
    {

    }

	public virtual DbSet<ConfirmationCode> ConfirmationCodes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CountryPhoneNumberMask> CountryPhoneNumberMasks { get; set; }

    public virtual DbSet<PolicyDocument> PolicyDocuments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserResidenceAddress> UserResidenceAddresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConfirmationCode>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.ConfirmationCodes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConfirmationCodes_UserId");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasIndex(e => e.Iso2Code, "UQ_Countries_Iso2Code").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Iso2Code).HasMaxLength(2);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.PhoneNumberCode).HasMaxLength(10);
        });

        modelBuilder.Entity<CountryPhoneNumberMask>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Mask).HasMaxLength(20);

            entity.HasOne(d => d.Country).WithMany(p => p.CountryPhoneNumberMasks)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CountryPhoneNumberMasks_CountryId");
        });

        modelBuilder.Entity<PolicyDocument>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserResidenceAddress>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ApartmentNumber).HasMaxLength(20);
            entity.Property(e => e.BuildingNumber).HasMaxLength(20);
            entity.Property(e => e.City).HasMaxLength(250);
            entity.Property(e => e.Street).HasMaxLength(250);

            entity.HasOne(d => d.Country).WithMany(p => p.UserResidenceAddresses)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserResidenceAddresses_CountryId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
