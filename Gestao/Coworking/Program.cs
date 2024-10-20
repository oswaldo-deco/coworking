var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseHttpsRedirection();

app.MapGet("/users", () =>
{
})

app.MapGet("/users/:id", () =>
{
})

app.MapPost("/users/:id", () =>
{
})

app.MapPut("/users/:id", () =>
{
})

app.MapDelete("/users/:id", () =>
{
})

app.MapGet("/spaces", () =>
{
})

app.MapGet("/spaces/:id", () =>
{
})

app.MapPost("/spaces/:id", () =>
{
})

app.MapPut("/spaces/:id", () =>
{
})

app.MapDelete("/spaces/:id", () =>
{
})

app.MapGet("/bookings", () =>
{
})

app.MapGet("/bookings/:id", () =>
{
})

app.MapPost("/bookings/:id", () =>
{
})

app.MapPut("/bookings/:id", () =>
{
})

app.MapDelete("/bookings/:id", () =>
{
})

app.MapGet("/payment", () =>
{
})

app.MapGet("/payment/:id", () =>
{
})

app.MapPost("/payment/:id", () =>
{
})

app.MapPut("/payment/:id", () =>
{
})

app.MapDelete("/payment/:id", () =>
{
})

app.MapGet("/kpi", () =>
{
})


app.MapPost("/login", () =>
{
})


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
