﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using the_enigma_casino_server.Core.Entities;

namespace the_enigma_casino_server.Infrastructure.Database.Config;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.ToTable("orders");

        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        entity.Property(e => e.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        entity.Property(e => e.CoinsPackId)
            .HasColumnName("coins_pack_id")
            .IsRequired();

        entity.Property(e => e.StripeSessionId)
            .HasColumnName("stripe_session_id");

        entity.Property(e => e.IsPaid)
            .HasColumnName("is_paid")
            .IsRequired();

        entity.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        entity.Property(e => e.PaidDate)
              .HasColumnName("paid_date");

        entity.Property(e => e.Price)
            .HasColumnName("price");

        entity.Property(e => e.Coins)
            .HasColumnName("coins");

        entity.Property(e => e.EthereumTransactionHash)
            .HasColumnName("ethereum_transaction_hash");

        entity.Property(e => e.PayMode)
            .HasColumnName("pay_mode");

        entity.Property(e => e.OrderType)
            .HasColumnName("order_type");

        entity.Property(e => e.EthereumPrice)
            .HasColumnName("ethereum_price");

        entity.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        entity.HasOne(o => o.CoinsPack)
            .WithMany()
            .HasForeignKey(o => o.CoinsPackId);
    }


}
