using ErrorHandling.Extensions;
using LoggerService;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nglog.config"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
//app.ConfigureExceptionHandler(logger);

app.ConfiguraCustomExceptionMiddleware();

if (app.Environment.IsProduction())
    app.UseHsts();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ConfigureExceptionHandler(logger);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
