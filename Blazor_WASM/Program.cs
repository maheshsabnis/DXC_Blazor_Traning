using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
namespace Blazor_WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // WebAssemblyHostBuilder: Generate a Wasm for the current application
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            // Load or Inject the Router Component for Routing in index.html in HTML element with is as 'app' 
            builder.RootComponents.Add<App>("#app");
            // DI Service Registration
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            // Register the Object as Singleton
            builder.Services.AddScoped<AppStateContainer>();
            // Register Storage Services For the Browser
            builder.Services.AddBlazoredSessionStorage();


            // Applicartion Build so that the execution (Running) will start in browser
            await builder.Build().RunAsync();
        }
    }
}
