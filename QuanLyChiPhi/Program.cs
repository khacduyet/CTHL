using Microsoft.EntityFrameworkCore;
using QuanLyChiPhi.Common;
using QuanLyChiPhi.Entities;
using QuanLyChiPhi.Model;

var builder = WebApplication.CreateBuilder(args);
// Database QuanLyChiPhi
ConfigurationManager configuration = builder.Configuration;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var contexOptions = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(connectionString).Options;
var appSettingsSectionOb = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSectionOb);
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString));
//end database

// 
builder.Services.AddSingleton<AppSettings>();
builder.Services.AddScoped<ApplicationContext>();
//
builder.Services.AddScoped<QuanLyChiPhi.Model.QuanLyChiPhi>();
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

