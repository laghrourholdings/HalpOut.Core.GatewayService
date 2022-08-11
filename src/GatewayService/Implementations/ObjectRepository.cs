using System.Linq.Expressions;
using CommonLibrary.Contracts.Gateway_Internal_Contracts;
using CommonLibrary.Entities.InternalService;
using CommonLibrary.Implementations;
using CommonLibrary.Interfaces;
using CommonLibrary.Repositories;
using CommonLibrary.Settings;
using Flurl;
using Flurl.Http;
using MassTransit;

namespace GatewayService.Implementations;

public class ObjectRepository : IObjectRepository<IObject>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public ObjectRepository(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task<IEnumerable<IObject>> GetAllAsync()
    {
        return await WebClientSettings.InternalServiceDevURL
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
            Console.WriteLine($"Requesting object creation with guid: {suggestedGuid}");
            await _publishEndpoint.Publish(new CreateObject(request));
        }
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