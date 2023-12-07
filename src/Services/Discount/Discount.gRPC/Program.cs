using Discount.gRPC.Repositories;
using Discount.gRPC.Repositories.Interfaces;
using Discount.gRPC.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Discount.gRPC.Extensions;
using Grpc.Core;
using Polly;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
//var hostBuilder = 

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
var app = builder.Build();

app.Services.MigrateDatabase<Program>();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");


app.Run();