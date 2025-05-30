﻿using Microsoft.EntityFrameworkCore;
using the_enigma_casino_server.Infrastructure.Database.Repositories;

namespace the_enigma_casino_server.Infrastructure.Database;

public class UnitOfWork
{
    private readonly MyDbContext _context;

    public MyDbContext DbContext => _context;



    // WEB
    private UserRepository _userRepository;
    private CoinsPackRepository _coinsPackRepository;
    private OrderRepository _orderRepository;
    private UserFriendRepository _userFriendRepository;
    private FriendRequestRepository _friendRequestRepository;

    public UserRepository UserRepository => _userRepository ??= new UserRepository(_context);
    public CoinsPackRepository CoinsPackRepository => _coinsPackRepository ??= new CoinsPackRepository(_context);
    public OrderRepository OrderRepository => _orderRepository ??= new OrderRepository(_context);


    // GAME
    private GameTableRepository _gameTableRepository;
    private GameHistoryRepository _gameHistoryRepository;

    public GameTableRepository GameTableRepository => _gameTableRepository ??= new GameTableRepository(_context);
    public GameHistoryRepository GameHistoryRepository => _gameHistoryRepository ??= new GameHistoryRepository(_context);


    // FRIENDS
    public FriendRequestRepository FriendRequestRepository => _friendRequestRepository ??= new FriendRequestRepository(_context);
    public UserFriendRepository UserFriendRepository => _userFriendRepository ??= new UserFriendRepository(_context);

    public UnitOfWork(MyDbContext myDbContext)
    {
        _context = myDbContext;
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
