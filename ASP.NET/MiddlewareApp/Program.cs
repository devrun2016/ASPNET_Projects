using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Welcome to Contoso!");

//Added Code Third
app.Use(async (context, next) => {
    await next();
    Console.WriteLine($"{context.Request.Method} {context.Request.Path} {context.Response.StatusCode}");
});

//Added Code Second
app.UseRewriter(new RewriteOptions().AddRedirect("history", "about"));

//Added Code First
app.MapGet("/about", () => "Contoso was founded in 2000.");

app.Run();

/*

app.Use() -> 현재 상황을 출력

app.MapGet(); -> 이는 현재 url에 새로운 경로를 /about으로 제공하고 내용을 출력 (web page)

app.UseRewriter() -> 이는 새로운 경로 /history를 생성하지만 경로로 이동하면 /about으로 redirection 한다.

*/