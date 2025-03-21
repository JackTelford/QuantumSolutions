using OrchardCore.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Environment.WebRootPath = Path.Combine(builder.Environment.ContentRootPath, "wwwroot");

builder.Host.UseNLogHost();
builder.Services.AddOrchardCms();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseOrchardCore();

app.Run();
