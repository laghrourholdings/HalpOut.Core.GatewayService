using System.Linq.Expressions;
using CommonLibrary.AspNetCore;
using CommonLibrary.AspNetCore.Contracts;
using CommonLibrary.AspNetCore.ServiceBus;
using CommonLibrary.AspNetCore.Settings;
using CommonLibrary.Core;
using CommonLibrary.Settings;
using Flurl;
using Flurl.Http;
using MassTransit;
using ILogger = Serilog.ILogger;

namespace GatewayService.Implementations;

public class ObjectRepository : IObjectRepository<IIObject>
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

    public async Task<IEnumerable<IIObject>> GetAllAsync()
    {
        return await ServicesSettings.InternalServiceDevURL
            .AppendPathSegment("objects")
            .GetJsonAsync<IEnumerable<IIObject>>();
    }

    public async Task<IEnumerable<IIObject>> GetAllAsync(Expression<Func<IIObject, bool>> filter)
    {
        return await ServicesSettings.InternalServiceDevURL
            .AppendPathSegment("objects")
            .GetJsonAsync<IEnumerable<IIObject>>();
    }

    public Task<IIObject> GetAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<IIObject> GetAsync(Expression<Func<IIObject, bool>> filter)
    {
        throw new NotImplementedException();
    }
    

    public async Task CreateAsync(IIObject? entity)
    {
        if(entity is null)
        {
            var request = new ServiceBusMessage
            {
                Descriptor = ServiceSettings.GetMessage($"Requesting object creation"),
                Contract = nameof(CreateObject),
            };
            _logger.Information("Object creating requested: {@Request}", request);
            await _publishEndpoint.Publish(new CreateObject(request));
        }
    }
    
    public Task UpdateAsync(IIObject entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrCreateAsync(
        IIObject entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(IIObject entity)
    {
        throw new NotImplementedException();
    }

    public Task SuspendAsync(IIObject entity)
    {
        throw new NotImplementedException();
    }
}