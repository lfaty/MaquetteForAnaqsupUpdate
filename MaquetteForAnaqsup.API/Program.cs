using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Mappings;
using MaquetteForAnaqsup.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Office.Interop.Excel;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Boost Performance with Caching
builder.Services.AddResponseCaching();

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.CacheProfiles.Add("apicache",
    new CacheProfile()
    {
        Duration = 30
    });
});

// Configuration de Serilog : Logging to Console
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/fichier_Log.txt", rollingInterval: RollingInterval.Minute)
    .MinimumLevel.Warning()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Maquette API", Version = "v1" });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddHttpContextAccessor();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Configuration Connection 
builder.Services.AddDbContext<ApplicationsDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuration Repository
//builder.Services.AddScoped<IUploadFilesService, UploadFilesService>();
builder.Services.AddScoped<IDatasService, DatasService>();
builder.Services.AddScoped<IAtomeElementConstitutifsService, AtomeElementConstitutifsService>();
builder.Services.AddScoped<IParcourUniteEnseignementsService, ParcourUniteEnseignementsService>();
builder.Services.AddScoped<INatureUEsService, NatureUEsService>();
builder.Services.AddScoped<ISemestresService, SemestresService>();
builder.Services.AddScoped<IGradesService, GradesService>();
builder.Services.AddScoped<INiveausService, NiveausService>();
builder.Services.AddScoped<IAtomePedagogiquesService, AtomePedagogiquesService>();
builder.Services.AddScoped<IDebouchesService, DebouchesService>();
builder.Services.AddScoped<IDepartementsService, DepartementsService>();
builder.Services.AddScoped<IDomainesService, DomainesService>();
builder.Services.AddScoped<IElementConstitutifsService, ElementConstitutifsService>();
builder.Services.AddScoped<IFacultesService, FacultesService>();
builder.Services.AddScoped<IFormationsService, FormationsService>();
//builder.Services.AddScoped<IImagesService, ImagesService>();
builder.Services.AddScoped<IMentionsService, MentionsService>();
builder.Services.AddScoped<IParcoursService, ParcoursService>();
builder.Services.AddScoped<ISpecialitesService, SpecialitesService>();
builder.Services.AddScoped<IUniteEnseignementsService, UniteEnseignementsService>();
builder.Services.AddScoped<IUniversitesService, UniversitesService>();
builder.Services.AddScoped<IVillesService, VillesService>();


// Configuration Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


// Configuration pour acceder à l'URL du fichier de l'image
var filesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadFile");
if (!Directory.Exists(filesPath))
{
    Directory.CreateDirectory(filesPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(filesPath),
    RequestPath = "/UploadFile"
});

app.MapControllers();

app.Run();
