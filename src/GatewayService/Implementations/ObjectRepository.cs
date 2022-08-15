using System.Linq.Expressions;
using CommonLibrary.AspNetCore;
using CommonLibrary.AspNetCore.Contracts;
using CommonLibrary.AspNetCore.Logging;
using CommonLibrary.AspNetCore.ServiceBus;
using CommonLibrary.Core;
using CommonLibrary.Settings;
using Flurl;
using Flurl.Http;
using MassTransit;
using ILogger = Serilog.ILogger;

namespace GatewayService.Implementations;

public class ObjectRepository : IObjectRepository<IObject>
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public ObjectRepository(
        IPublishEndpoint publishEndpoint,
        IConfiguration configuration,
        ILogger logger)
    {
        _publishEndpoint = publishEndpoint;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<IEnumerable<IObject>> GetAllAsync()
    {
        return await ServicesSettings.InternalServiceDevURL
            .AppendPathSegment("objects")
            .GetJsonAsync<IEnumerable<IIObject>>();
    }

    public Task<IEnumerable<IObject>> GetAllAsync(Expression<Func<IObject, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<IObject> GetAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<IObject> GetAsync(Expression<Func<IObject, bool>> filter)
    {
        throw new NotImplementedException();
    }
    

    public async Task CreateAsync(IObject? entity)
    {
        if(entity is null)
        {
            var suggestedGuid = Guid.NewGuid();
            var request = new ServiceBusRequest<Guid>
            {
                Subject = suggestedGuid,
                Descriptor = $"Requesting object creation with guid: {suggestedGuid}",
                Contract = nameof(CreateObject)
            };
            _logger.General($"Testing: {@request}");
            var logContext = request.GetLogContext(_configuration, LogLevel.Information);
            _logger.GeneralToBusLog(
                logContext,
                $"Requesting object creation with guid: {suggestedGuid}",
                _publishEndpoint, new LogObjectCreate(logContext));
            await _publishEndpoint.Publish(new CreateObject(request));

        }
    }

    public Task BindLogHandle(Guid objectId, Guid logHandle)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(IObject entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(IObject entity)
    {
        throw new NotImplementedException();
    }

    public Task SuspendAsync(IObject entity)
    {
        throw new NotImplementedException();
    }
}