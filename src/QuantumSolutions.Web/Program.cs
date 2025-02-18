using OrchardCore.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNLogHost();
builder.Services.AddOrchardCms();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseOrchardCore();
app.Run();
