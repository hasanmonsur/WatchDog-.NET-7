using WatchDog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddWatchDogServices(opt =>
{
    opt.SqlDriverOption = WatchDog.src.Enums.WatchDogSqlDriverEnum.PostgreSql;
    opt.SetExternalDbConnString = "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=postgres;SearchPath=dbwatchdog;";
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWatchDogExceptionLogger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseWatchDog(conf =>
{
    conf.WatchPageUsername = "admin";
    conf.WatchPagePassword = "Qwerty@123";
});

app.Run();
