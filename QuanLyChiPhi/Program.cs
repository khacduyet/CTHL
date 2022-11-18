using Microsoft.EntityFrameworkCore;
using QuanLyChiPhi.Common;
using QuanLyChiPhi.Entities;
using QuanLyChiPhi.Model;
using static QuanLyChiPhi.Model.FileUploader;

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
builder.Services.AddScoped<QuanLyChiPhi.Model.FileUploader>();
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials());
});

builder.Services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
if (config.AutoUpdate == 1)
{
    var serviceScope = builder.Services.BuildServiceProvider().GetService<IServiceScopeFactory>().CreateScope();
    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
    context.Database.Migrate();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.MapPost("FileUploader/Post", (HttpRequest postRequest) =>
{
    if (!postRequest.Form.Files.Any())
    {
        return Results.BadRequest("Không có file nào được đính kèm");
    }
    string urlUpload = @"c:\uploader\App_Data\uploads\";
    List<HDFileUpload> files = new List<HDFileUpload>();
    foreach (var item in postRequest.Form.Files)
    {
        string extension = item.FileName.Split('.').Last();
        var filenamebase64 = Dungchung.Base64Encode(Guid.NewGuid().ToString() + item.FileName);
        var pathbase64 = Dungchung.Base64Encode(urlUpload + "/" + item.FileName);
        var path = filenamebase64 + "." + extension;
        using (var stream = new FileStream(urlUpload + path, FileMode.Create))
        {
            files.Add(new HDFileUpload(path, item.FileName, postRequest.Host + "?filename=" + filenamebase64 + "&path=" + pathbase64, (item.Length / 1024).ToString()));
            item.CopyTo(stream);
        }
    }
    return Results.Ok(new { Message = "Tải lên thành công!", Files = files });
});

app.Run();

