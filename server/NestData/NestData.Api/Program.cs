using NestData;

var builder = WebApplication.CreateBuilder(args);

Configure.ConfigureBuilder(builder);

var app = builder.Build();

Configure.ConfigureApp(app);
app.Run();