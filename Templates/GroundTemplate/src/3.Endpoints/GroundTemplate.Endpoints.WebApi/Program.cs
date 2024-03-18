using Ground.Extensions.DependencyInjection;
using Ground.Utilities.SerilogRegistration.Extensions;
using GroundTemplate.Endpoints.WebApi.Extentions;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.AddGroundSerilog(c =>
    {
        c.ApplicationName = builder.Configuration["ApplicationName"];
        c.ServiceName = builder.Configuration["ServiceName"];
        c.ServiceVersion = builder.Configuration["ServiceVersion"];
        c.ServiceId = Guid.NewGuid().ToString();
    }).ConfigureServices().ConfigurePipeline();
    app.Run();
});