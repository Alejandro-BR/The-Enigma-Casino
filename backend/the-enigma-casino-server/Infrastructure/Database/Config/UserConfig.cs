﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using the_enigma_casino_server.Core.Entities;

namespace the_enigma_casino_server.Infrastructure.Database.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("users");

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
              .HasColumnName("id")
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(e => e.NickName)
              .HasColumnName("nickname")
              .HasMaxLength(20)
              .IsRequired();

        entity.Property(e => e.FullName)
              .HasColumnName("fullname")
              .HasMaxLength(100)
              .IsRequired();

        entity.Property(e => e.Email)
              .HasColumnName("email")
              .HasMaxLength(100)
              .IsRequired();

        entity.Property(e => e.HashPassword)
              .HasColumnName("hash_password")
              .HasMaxLength(64)
              .IsRequired();

        entity.Property(e => e.Role)
              .HasColumnName("role")
              .IsRequired();

        entity.Property(e => e.Address)
              .HasColumnName("address")
              .HasMaxLength(250)
              .IsRequired();

        entity.Property(e => e.Country)
            .HasColumnName("country")
                .HasMaxLength(3)
                .IsRequired();

        entity.Property(e => e.Image)
            .HasColumnName("image")
                .HasMaxLength(100)
                .IsRequired();


        entity.Property(e => e.Coins)
            .HasColumnName("coins")
                .IsRequired();

        entity.Property(e => e.IsSelfBanned)
            .HasColumnName("is_self_banned")
                .IsRequired();

        entity.Property(e => e.DateOfBirth)
              .HasColumnName("date_of_birth")
              .IsRequired();

        entity.Property(e => e.SelfBannedAt)
              .HasColumnName("self_banned_at")
                .HasColumnType("datetime")
                    .IsRequired(false);

        entity.Property(e => e.EmailConfirm)
              .HasColumnName("email_confirm")
              .IsRequired();

        entity.Property(e => e.ConfirmationToken)
            .HasColumnName("confirmation_token");

        // IsUnique 
        entity.HasIndex(e => e.Email)
              .IsUnique();
        entity.HasIndex(e => e.NickName)
              .IsUnique();
    }
}
