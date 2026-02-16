using DYS.Devyard.Web;
using DYS.Devyard.Web.Shared.Extensions;
using DYS.Devyard.Web.Shared.Settings;
using DYS.Devyard.Web.Shared.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMvvm();

builder.Services.AddScopedForBaseClass<BaseViewModel>(Assembly.GetExecutingAssembly());
builder.Services.AddOtherServices();
builder.Services.AddAutoMapper(config => { }, typeof(Automappings));


await builder.Build().RunAsync();
