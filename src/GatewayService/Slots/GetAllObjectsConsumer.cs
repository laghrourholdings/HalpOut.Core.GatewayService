using CommonLibrary.AspNetCore;
using CommonLibrary.AspNetCore.Contracts;
using CommonLibrary.Core;
using MassTransit;

namespace GatewayService.Slots;

public class GetAllObjectsConsumer : IConsumer<GetAllObjectsResponse>
{
    
    private readonly IObjectRepository<IIObject> _objectRepository;
    
    public GetAllObjectsConsumer(IObjectRepository<IIObject> objectRepository)
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