using Microsoft.Extensions.Options;
using swBackend.Interfaces;
using swBackend.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<InfoRepository>();

//builder.Services.AddHttpClient<SWAPIService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                           .AllowAnyHeader()
                                           .AllowAnyMethod();
                      });
});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
