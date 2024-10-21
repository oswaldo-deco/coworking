using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//Adicionando o serviço de banco de dados na aplicação
builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/user", ([FromServices] AppDataContext ctx) =>
{
    if(ctx.User.Any())
    {
        return Results.Ok(ctx.User.ToList());
    }
    return Results.NotFound();
});

app.MapGet("/user/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    User? user = ctx.User.Find(id);

    if (user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);
});

app.UserPost("/user", ([FromBody] User user) =>
{
    ctx.User.Add(user);
    ctx.SaveChanges();
    return Results.Created();
});

app.MapPut("/User/{id}", ([FromBody] User user) =>
{
    User? user = ctx.User.Find(id);
    if (user == null)
    {
        return Results.NotFound();
    }
    user.Name = userAlterado.Name;
    user.Email = userAlterado.Email;
    user.Cellphone = userAlterado.Cellphone;
    user.TaxNumber = userAlterado.TaxNumber;
    user.Password = userAlterado.Password;
    ctx.User.Update(user);
    ctx.SaveChanges();
    return Results.Ok(user);
});

app.MapDelete("/User/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    User? user = ctx.User.Find(id);
    
    if (user == null)
    {
        return Results.NotFound();
    }

    ctx.User.Remove(user);
    ctx.SaveChanges();
    return Results.Ok(user);
});

app.MapGet("/spaces", ([FromServices] AppDataContext ctx) =>
{
    if(ctx.User.Any())
    {
        return Results.Ok(ctx.Spaces.Tolist());
    }
    return Results.NotFound();
});

app.MapGet("/spaces/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    User? user = ctx.Spaces.Find(id);

    if (user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);
});

app.MapPost("/spaces", ([FromBody] Spaces space) =>
{
    ctx.Spaces.Add(space);
    ctx.SaveChanges();
    return Results.Created();
});

app.MapPut("/spaces/{id}", ([FromBody] Spaces space) =>
{
    Space? existingSpace = ctx.Space.Find(id);
    if (user == null)
    {
        return Results.NotFound();
    }
    existingSpace.Name = space.Name;
    existingSpace.Capacity = space.Capacity;
    existingSpace.PricePerHour = space.PricePerHour;
    ctx.User.Update(user);
    ctx.SaveChanges();
    return Results.Ok(user);
});

app.MapDelete("/spaces/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
        Space? spaceToRemove = ctx.Space.Find(id);
        if (spaceToRemove != null)
        {
            _context.Spaces.Remove(spaceToRemove);
            _context.SaveChanges();
        }
});

app.MapGet("/bookings", ([FromServices] AppDataContext ctx) =>
{
    if(ctx.Bookings.Any())
    {
        return Results.Ok(ctx.Bookings.Tolist());
    }
    return Results.NotFound();
});

app.MapGet("/bookings/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    Bookings? bookings = ctx.Bookings.Find(id);

    if (bookings == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(bookings);
});

app.MapPost("/bookings", ([FromBody] Bookings bookings) =>
{
    ctx.Bookings.Add(bookings);
    ctx.SaveChanges();
    return Results.Created();
});

app.MapPut("/bookings/{id}", ([FromBody] Bookings bookings) =>
{
    BookingsService.update();
});

app.MapDelete("/bookings/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    Bookings? bookings = ctx.Bookings.Find(id);
    
    if (bookings == null)
    {
        return Results.NotFound();
    }

    ctx.Bookings.Remove(bookings);
    ctx.SaveChanges();
    return Results.Ok(bookings);
});

app.MapGet("/payment", ([FromServices] AppDataContext ctx) =>
{
    PaymentService.getAll();
});

app.MapGet("/payment/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    PaymentService.getById();
});

app.MapPost("/payment/{id}", ([FromBody] Payment payment) =>
{
    PaymentService.create();
});

app.MapPut("/payment/{id}", ([FromBody] Payment payment) =>
{
    PaymentService.update();
});

app.MapDelete("/payment/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    PaymentService.delete();
});

app.MapGet("/kpi", ([FromServices] AppDataContext ctx) =>
{
});


app.MapPost("/login", ([FromBody] Login login) =>
{
});


app.Run();