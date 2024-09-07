using Hangfire;
using Reflection;
using Reflection.Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.AddSimpleConsole(
    options => options.TimestampFormat = "yyyy-MM-dd HH:mm:ss "
);

RegisterServices.Register(builder.Services);

var app = builder.Build();

app.UseHangfireDashboard("/jobs", new DashboardOptions() 
{
    Authorization = [new HangFireAuthorizationFilter()]
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
