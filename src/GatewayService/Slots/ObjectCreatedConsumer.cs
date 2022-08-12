using CommonLibrary.AspNetCore.Contracts.Gateway_Internal_Contracts;
using CommonLibrary.Core;
using CommonLibrary.Repositories;
using MassTransit;

namespace GatewayService.Slots;

public class ObjectCreatedConsumer : IConsumer<CreateObjectResponse>
{
    
    private readonly IObjectRepository<IObject> _objectRepository;
    
    public ObjectCreatedConsumer(IObjectRepository<IObject> objectRepository)
    {
        _objectRepository = objectRepository;
    }
    
    public async Task Consume(ConsumeContext<CreateObjectResponse> context)
    {
        var message = context.Message.Payload;
        Console.WriteLine($"Creation for: {message.Subject.Id} created at: {message.Subject.CreationDate} COMPLETED");
        await Task.CompletedTask;
    }
}