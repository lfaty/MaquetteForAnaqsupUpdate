using MaquetteForAnaqsup.UI.ApiServices;

var builder = WebApplication.CreateBuilder(args);

string? apiUrl = builder.Configuration["ApiUrl"];
if (string.IsNullOrEmpty(apiUrl))
{
    throw new InvalidOperationException("La configuration 'ApiUrl' est manquante ou vide.");
}

builder.Services.AddHttpClient("custom-httpclient", httpClient =>
{
    httpClient.BaseAddress = new Uri(apiUrl);
});

// API Services
builder.Services.AddSingleton<DashboardsApiService>();
builder.Services.AddSingleton<DataDashboardsApiService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 jours. Vous pouvez vouloir changer cela pour des scénarios de production, voir https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
