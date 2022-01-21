using ToolsApp.Web.Data;

using Microsoft.EntityFrameworkCore;

using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

//using ToolsApp.Web.Data;
using ToolsApp.Services.Colors;
using ToolsApp.Services.Cars;
using ToolsApp.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ToolsAppContext>(options => {
  options.UseSqlServer(builder.Configuration["ConnectionString"]);
});

builder.Services
  .AddBlazorise(options =>
  {
    options.ChangeTextOnKeyPress = true; // optional
        })
  .AddBootstrapProviders()
  .AddFontAwesomeIcons();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<WeatherForecastService>();


builder.Services.AddSingleton<IColorsService, ColorsServiceMemory>();

if (builder.Configuration["UseDatabase"] == "true") {
  builder.Services.AddScoped<CarsData>();
  builder.Services.AddScoped<ICarsService, CarsServiceDatabase>();
}
else {
  builder.Services.AddSingleton<ICarsService, CarsServiceMemory>();
}



builder.Services.AddScoped<CarToolStoreService>();
builder.Services.AddScoped<ColorToolStoreService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
