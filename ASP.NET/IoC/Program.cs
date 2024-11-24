using MyWebApp.Interfaces;
using MyWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// 서비스 등록
builder.Services.AddTransient<IWelcomeService, WelcomeService>();

var app = builder.Build();

// DI를 통해 서비스 사용
//app.MapGet("/", (IWelcomeService welcomeService) => welcomeService.GetWelcomeMessage());

//새로운 코드
app.MapGet("/", async (IWelcomeService welcomeService1, IWelcomeService welcomeService2) => {
    string message1 = $"Message1: {welcomeService1.GetWelcomeMessage()}";
    string message2 = $"Message2: {welcomeService2.GetWelcomeMessage()}";
    return $"{message1}\n{message2}";
});

app.Run();
