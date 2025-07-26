using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Identity.Data;
using MaquetteForAnaqsup.API.Mappings;
using MaquetteForAnaqsup.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Office.Interop.Excel;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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

// Configuration Connection 
builder.Services.AddDbContext<ApplicationsDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuration Identity
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection")));

// Configuration HttpContextAccessor
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddJsonOptions(options =>
    { 
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Anaq-Sup API", Version = "v1" });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "Oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});


// Add Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
})
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

// Add Identity Services
builder.Services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, UserClaimsPrincipalFactory<IdentityUser, IdentityRole>>();

// Config Identity Options
builder.Services.Configure<IdentityOptions>(options =>
{
    //Add Config for Required Email
    options.SignIn.RequireConfirmedEmail = true;
    // Password settings
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(10));

// Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        AuthenticationType = "Jwt",
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

//Add services.AddMemoryCache()
//builder.Services.AddMemoryCache();

// Add services.AddCors()
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


// Configuration Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
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

Console.WriteLine("App Start");

app.MapControllers();


app.Run();
