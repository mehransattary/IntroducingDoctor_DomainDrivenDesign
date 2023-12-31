
using Doctor.BlazorWasm.Ui;
using Doctor.BlazorWasm.Ui.Infrastracture;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

const string baseAddress = "http://localhost:5171/api/";

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

builder.Services.RegisterApiServices();


await builder.Build().RunAsync();
