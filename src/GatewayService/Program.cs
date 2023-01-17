using CommonLibrary.AspNetCore.Core;
using CommonLibrary.Core;
using CommonLibrary.Logging.Models.Dtos;
using GatewayService.Logging.Implementations;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var logger = new LoggerConfiguration().WriteTo.Console();
builder.Services.AddCommonLibrary(builder.Configuration, builder.Logging, logger , MyAllowSpecificOrigins);
builder.Services.AddCommonLibraryLoggingService();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<LogHandleDto>, LogHandleRepository>();
var app = builder.Build();
app.UseCommonLibrary(MyAllowSpecificOrigins);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();