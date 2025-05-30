﻿using Nethereum.Util;
using the_enigma_casino_server.Core.Entities.Enum;

namespace the_enigma_casino_server.Core.Entities;

public class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public int CoinsPackId { get; set; }

    public CoinsPack CoinsPack { get; set; }

    public string StripeSessionId { get; set; }

    public string EthereumTransactionHash { get; set; }

    public bool IsPaid { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime PaidDate { get; set; }

    public int Price { get; set; }

    public int Coins { get; set; }

    public PayMode PayMode { get; set; }

    public OrderType OrderType { get; set; }

    public decimal EthereumPrice { get; set; }

    public Order()
    {

    }

    public Order(User user, CoinsPack coinsPack)
    {
        IsPaid = false;
        CreatedAt = DateTime.Now;

        User = user;
        UserId = user.Id;

        CoinsPack = coinsPack;
        CoinsPackId = coinsPack.Id;

        Price = coinsPack.Price;
        Coins = coinsPack.Quantity;

        EthereumPrice = 0;
    }

    public Order(User user)
    {
        User = user;
    }
}
