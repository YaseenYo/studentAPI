using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StudentAPI.Application;
using StudentAPI.Infrastructure;
using StudentAPI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICollegeDbSettings>(sp =>
                sp.GetRequiredService<IOptions<CollegeDbSettings>>().Value);

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICredentialsRepository, CredentialsRepository>();

builder.Services.Configure<CollegeDbSettings>(
                builder.Configuration.GetSection(nameof(CollegeDbSettings)));

builder.Services.AddApplication();

builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(builder.Configuration.GetValue<string>("CollegeDbSettings:ConnectionString")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();

        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();

