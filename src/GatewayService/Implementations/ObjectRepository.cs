using System.Linq.Expressions;
using CommonLibrary.Contracts.Gateway_Internal_Contracts;
using CommonLibrary.Entities.InternalService;
using CommonLibrary.Implementations.InternalService;
using CommonLibrary.Repository;
using MassTransit;

namespace GatewayService.Implementations;

public class ObjectRepository : IObjectRepository<IObject>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public ObjectRepository(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    public Task<IReadOnlyCollection<IObject>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<IObject>> GetAllAsync(Expression<Func<IObject, bool>> filter)
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

    public async Task CreateAsync(IObject entity)
    {
        await _publishEndpoint.Publish(new CreateObject(entity));
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