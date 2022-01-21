using ToolsAppDemo.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using ToolsAppDemo.Client.Interfaces;
using ToolsAppDemo.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddScoped<IColorsDataService, ColorsInMemoryDataService>();
builder.Services.AddScoped<IColorsDataService, ColorsApiDataService>();

//builder.Services.AddScoped<ICarsDataService, CarsInMemoryDataService>();
builder.Services.AddScoped<ICarsDataService, CarsApiDataService>();

builder.Services.AddScoped<ScreenBlockerService>();


await builder.Build().RunAsync();

