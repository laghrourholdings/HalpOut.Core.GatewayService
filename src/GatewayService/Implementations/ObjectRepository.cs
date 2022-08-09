using System.Linq.Expressions;
using CommonLibrary.Contracts.Gateway_Internal_Contracts;
using CommonLibrary.Implementations.InternalService;
using CommonLibrary.Repository;
using MassTransit;

namespace GatewayService.Implementations;

public class ObjectRepository : IObjectRepository<IIObject>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public ObjectRepository(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    public Task<IReadOnlyCollection<IIObject>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<IIObject>> GetAllAsync(Expression<Func<IIObject, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<IIObject> GetAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<IIObject> GetAsync(Expression<Func<IIObject, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(IIObject entity)
    {
        await _publishEndpoint.Publish(new CreateObject(entity));
    }

    public Task UpdateAsync(IIObject entity)
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