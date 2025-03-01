using Music.Contracts;
using Music.Entity;
using Music.EntityFramework;
using Music.HttpApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.ConfigureCors();
builder.Services.AddScoped<MusicContext>();
builder.Services.ConfigureRepositoryWrapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AnyPolicy"); //在管道里面使用这个服务（名称是：AnyPolicy）打通前后端

app.UseAuthorization();

app.MapControllers();

app.Run();
