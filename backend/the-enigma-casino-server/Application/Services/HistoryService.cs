﻿using the_enigma_casino_server.Application.Dtos;
using the_enigma_casino_server.Application.Mappers;
using the_enigma_casino_server.Core.Entities;
using the_enigma_casino_server.Games.Shared.Entities;
using the_enigma_casino_server.Infrastructure.Database;

namespace the_enigma_casino_server.Application.Services;

public class HistoryService : BaseService
{
    private GameHistoryMapper _gameHistoryMapper;

    private readonly static int AMOUNT = 5;

    public HistoryService(UnitOfWork unitOfWork, GameHistoryMapper gameHistoryMapper) : base(unitOfWork)
    {
        _gameHistoryMapper = gameHistoryMapper;
    }

    public async Task<HistoryDto> GetHistory(int id, int page)
    {
        User user = await GetUserById(id);

        if (user == null)
            throw new KeyNotFoundException($"No se encontró un usuario con el ID {id}.");

        List<History> gameHistories = await _unitOfWork.GameHistoryRepository.GetByUserIdAsync(user.Id);

        if (gameHistories == null || gameHistories.Count == 0)
            throw new KeyNotFoundException($"El usuario con ID {user.Id} no tiene historial de partidas.");

        int totalPages = (int)Math.Ceiling(gameHistories.Count / (double)AMOUNT);

        if (page < 1 || page > totalPages)
            throw new ArgumentOutOfRangeException(nameof(page), $"La página {page} está fuera del rango permitido (1 - {totalPages}).");

        List<History> pagedHistory = gameHistories
            .Skip((page - 1) * AMOUNT)
            .Take(AMOUNT)
            .ToList();

        List<GamesDto> gamesDtos = _gameHistoryMapper.ToListGamesDto(pagedHistory);

        return new HistoryDto(gamesDtos, totalPages, page);
    }

    public async Task<HistoryDto> GetOtherHistory(int id, int page)
    {
        User user = await GetUserById(id);
        if (user == null)
            throw new KeyNotFoundException($"No se encontró un usuario con el ID {id}.");

        int totalCount = await _unitOfWork.GameHistoryRepository.CountByUserIdAsync(user.Id);
        int totalPages = (int)Math.Ceiling(totalCount / (double)AMOUNT);

        if (page < 1 || page > totalPages)
            throw new ArgumentOutOfRangeException(nameof(page), $"La página {page} está fuera del rango permitido (1 - {totalPages}).");

        var pagedHistory = await _unitOfWork.GameHistoryRepository
            .GetByUserIdPagedAsync(user.Id, page, AMOUNT);

        var gamesDtos = _gameHistoryMapper.ToListGamesDto(pagedHistory);

        return new HistoryDto(gamesDtos, totalPages, page);
    }
}
