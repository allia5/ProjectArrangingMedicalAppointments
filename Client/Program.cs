using Blazored.LocalStorage;
using Client;
using Client.Services.Foundations.LocalStorageService;
using Client.Services.Foundations.LoginService;
using Client.Services.Foundations.SignInService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");


builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7104/") });
builder.Services.AddScoped<ISignInService, SignInService>();
builder.Services.AddScoped<ILocalStorageServices, LocalStorageServices>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddBlazoredLocalStorage();
await builder.Build().RunAsync();
