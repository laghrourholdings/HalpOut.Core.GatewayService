using CommonLibrary.Contracts.Gateway_Internal_Contracts;
using CommonLibrary.Implementations.InternalService;
using CommonLibrary.Repository;
using MassTransit;

namespace GatewayService.Slots;

public class ObjectCreatedConsumer
{
    
    private readonly IObjectRepository<IIObject> _repository;
    
    public ObjectCreatedConsumer(IObjectRepository<IIObject> repository)
    {
        _repository = repository;
    }
    
    public async Task Consume(ConsumeContext<CreateObject> context)
    {
        var message = context.Message;
        // var item = await _repository.GetAsync(message.ItemId);
        // if (item != null)
        // {
        //     return;
        // }
        // item = new CatalogItem()
        // {
        //     Id = message.ItemId,
        //     Name = message.Name,
        //     Description = message.Description
        // };
        Console.WriteLine($"Verification for: {message.obj.Id} created at: {message.obj.CreationDate} COMPLETED");
        //await _repository.CreateAsync(item);
        await Task.CompletedTask;
    }
}