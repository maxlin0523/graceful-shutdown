var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Lifetime.ApplicationStopping.Register(() => {
    app.Logger.LogInformation($"{DateTime.Now:mm:ss.fff} ApplicationStopping");
    Task.Run(() => Task1());  // Task1 excuting
    Task.Run(() => Task2());  // Task2 excuting
    Task.Delay(20000).Wait(); // Wait for 20 s, then it's done."
});


app.Lifetime.ApplicationStopped.Register(() => {
    app.Logger.LogInformation($"{DateTime.Now:mm:ss.fff} ApplicationStopped");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task Task1() 
{
    app.Logger.LogInformation($"{DateTime.Now:mm:ss.fff} Task1 has not been completed.");
    await Task.Delay(10000);
    app.Logger.LogInformation($"{DateTime.Now:mm:ss.fff} Task1 is completed.");
}

async Task Task2()
{
    app.Logger.LogInformation($"{DateTime.Now:mm:ss.fff} Task2 has not been completed.");
    await Task.Delay(5000);
    app.Logger.LogInformation($"{DateTime.Now:mm:ss.fff} Task2 is completed.");
}
