var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Change Hello World -> Hello .NET Developer Community!
app.MapGet("/", () => "Hello .NET Developer Community!");

app.Run();
