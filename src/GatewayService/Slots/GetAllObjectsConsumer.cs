using CommonLibrary.Contracts.Gateway_Internal_Contracts;
using CommonLibrary.Entities.InternalService;
using CommonLibrary.Repositories;
using MassTransit;

namespace GatewayService.Slots;

public class GetAllObjectsConsumer : IConsumer<GetAllObjectsResponse>
{
    
    private readonly IObjectRepository<IObject> _objectRepository;
    
    public GetAllObjectsConsumer(IObjectRepository<IObject> objectRepository)
    {
        _objectRepository = objectRepository;
    }
    
    public async Task Consume(ConsumeContext<GetAllObjectsResponse> context)
    {
        var message = context.Message.Payload;
        Console.WriteLine($"Creation for: {message.Subject.Id} created at: {message.Subject.CreationDate} COMPLETED");
        await Task.CompletedTask;
    }
}