using System.Linq.Expressions;
using CommonLibrary.Contracts.Gateway_Internal_Contracts;
using CommonLibrary.Entities.InternalService;
using CommonLibrary.Implementations;
using CommonLibrary.Repositories;
using MassTransit;

namespace GatewayService.Implementations;

public class ObjectRepository : IObjectRepository
{
    private readonly IPublishEndpoint _publishEndpoint;

    public ObjectRepository(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public Task<IEnumerable<IObject>> GetAllAsync()
    {
        throw new NotImplementedException();
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
            var request = new ServiceBusRequest<Guid>();
            var suggestedGuid = Guid.NewGuid();
            request.Subject = suggestedGuid;
            request.Descriptor = "Requesting object creation";
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