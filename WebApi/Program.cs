using Microsoft.OpenApi.Models;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

//var app = builder.Build();
var app = builder.ConfigureServices()
                 .ConfigurePipeline();

app.Run();
