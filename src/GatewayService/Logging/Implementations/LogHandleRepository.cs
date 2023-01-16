﻿using System.Linq.Expressions;
using CommonLibrary.Core;
using CommonLibrary.Logging.Models.Dtos;
using Flurl;
using Flurl.Http;

namespace GatewayService.Logging.Implementations;

public class LogHandleRepository : IRepository<LogHandleDto>
{
    public async Task<IEnumerable<LogHandleDto>?> GetAllAsync()
    {
        return await ServicesSettings.LogServiceDevURL
            .AppendPathSegment("logs/handles")
            .GetJsonAsync<IEnumerable<LogHandleDto>>();
    }

    public Task<IEnumerable<LogHandleDto>?> GetAllAsync(
        Expression<Func<LogHandleDto, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<LogHandleDto?> GetAsync(
        Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<LogHandleDto?> GetAsync(
        Expression<Func<LogHandleDto, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(
        LogHandleDto entity)
    {
        throw new NotImplementedException();
    }

    public Task RangeAsync(
        IEnumerable<LogHandleDto> entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(
        LogHandleDto entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrCreateAsync(
        LogHandleDto entity)
    {
        throw new NotImplementedException();
    }
}