using API.Data.BDD;
using API.Data.initialize;
using monapi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//RESET FOR PROPER TESTING
bool ResetOnStartForTesting = true;
// CHANGE HERE IF NEEDED

if (!Directory.Exists(Const.patternsDirectory))
    Directory.CreateDirectory(Const.patternsDirectory);

if (ResetOnStartForTesting)
{
    SendDataController sdc = new SendDataController();
    sdc.clearAll();
    initialise.MoveTestingPatterns();
}



app.Run();
