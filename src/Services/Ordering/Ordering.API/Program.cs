var builder = WebApplication.CreateBuilder(args);

// Connection connection string in aspSetting.json
var dbConntection = builder.Configuration.GetConnectionString("Database");

// Add Services to the container
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();


var app = builder.Build();

// Configure the Http request pipeline
app.UseApiService();

if(app.Environment.IsDevelopment())
    await app.InitialiseDatabaseAsync();

app.Run();
