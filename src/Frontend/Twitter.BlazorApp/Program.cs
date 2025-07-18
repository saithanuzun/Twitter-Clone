using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Twitter.BlazorApp;
using Twitter.BlazorApp.Infrastructure.Services;
using Twitter.BlazorApp.Infrastructure.Services.Interfaces;
using Twitter.BlazorApp.Infrastructure.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7267")
});

builder.Services.AddTransient<ITweetService, TweetService>();
builder.Services.AddTransient<IHashtagService, HashtagService>();
builder.Services.AddTransient<IUserService, UserService>();

await builder.Build().RunAsync();