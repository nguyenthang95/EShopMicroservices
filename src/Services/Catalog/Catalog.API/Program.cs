var builder = WebApplication.CreateBuilder(args);
// Connection DB string in aspSetting.json
var dbConntection = builder.Configuration.GetConnectionString("Database");
// Add Services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(dbConntection!);
}).UseLightweightSessions();

// Configure the HTTP request Pipeline.
var app = builder.Build();

app.MapCarter();

app.Run();
