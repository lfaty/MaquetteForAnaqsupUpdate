using MaquetteForAnaqsup.UI.ApiServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("custom-httpclient", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7136/api/");
});

// API Services
builder.Services.AddSingleton<DashboardsApiService>();
builder.Services.AddSingleton<DataDashboardsApiService>();

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
