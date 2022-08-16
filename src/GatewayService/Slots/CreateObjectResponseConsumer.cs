using CommonLibrary.AspNetCore;
using CommonLibrary.AspNetCore.Contracts;
using CommonLibrary.Core;
using MassTransit;
using ILogger = Serilog.ILogger;

namespace GatewayService.Slots;

public class CreateObjectResponseConsumer : IConsumer<CreateObjectResponse>
{
    
    private readonly IObjectRepository<IIObject> _objectRepository;
    private readonly ILogger _logger;

    public CreateObjectResponseConsumer(IObjectRepository<IIObject> objectRepository, ILogger logger)
    {
        _logger = logger;
        _objectRepository = objectRepository;
    }
    
    public async Task Consume(ConsumeContext<CreateObjectResponse> context)
    {
        var message = context.Message.Payload;
        _logger.Information("Creation for: {@message.Subject} COMPLETED",message.Subject);
        await Task.CompletedTask;
    }
}