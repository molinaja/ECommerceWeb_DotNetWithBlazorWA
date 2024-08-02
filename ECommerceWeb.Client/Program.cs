
using Blazored.SessionStorage;
using Blazored.Toast;
using BlazorSpinner;
using CurrieTechnologies.Razor.SweetAlert2;
using ECommerceWeb.Client;
using ECommerceWeb.Client.Auth;
using ECommerceWeb.Client.Proxy;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<SpinnerService>();
builder.Services.AddScoped<LoadingService>();
builder.Services.AddScoped<IUserProxy, UserProxy>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationService>();

builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
