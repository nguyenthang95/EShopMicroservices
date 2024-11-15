var builder = WebApplication.CreateBuilder(args);

// Add services to the container


// Configure the Http request pipeline
var app = builder.Build();

app.Run();