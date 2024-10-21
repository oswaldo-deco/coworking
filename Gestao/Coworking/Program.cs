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

app.MapPost("/user", ([FromServices] AppDataContext ctx, [FromBody] User user) =>
{
    ctx.User.Add(user);
    ctx.SaveChanges();
    return Results.Created();
});

app.MapPut("/User/{id}", ([FromServices] AppDataContext ctx, [FromBody] User userAlterado, [FromRoute] string id) =>
{
    User? userFound = ctx.User.Find(id);
    
    if (userFound == null)
    {
        return Results.NotFound();
    }
    userFound.Name = userAlterado.Name;
    userFound.Email = userAlterado.Email;
    userFound.Cellphone = userAlterado.Cellphone;
    userFound.taxNumber = userAlterado.taxNumber;
    userFound.Password = userAlterado.Password;
    ctx.User.Update(userFound);
    ctx.SaveChanges();
    return Results.Ok(userFound);
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
        return Results.Ok(ctx.Spaces.ToList());
    }
    return Results.NotFound();
});

app.MapGet("/spaces//{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    Spaces? space = ctx.Spaces.Find(id);

    if (space == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(space);
});

app.MapPost("/spaces", ([FromServices] AppDataContext ctx, [FromBody] Spaces space) =>
{
    ctx.Spaces.Add(space);
    ctx.SaveChanges();
    return Results.Created();
});

app.MapPut("/spaces/{id}", ([FromServices] AppDataContext ctx, [FromBody] Spaces space, [FromRoute] string id) =>
{
    Spaces? existingSpace = ctx.Spaces.Find(id);
    if (existingSpace == null)
    {
        return Results.NotFound();
    }
    existingSpace.Name = space.Name;
    existingSpace.Capacity = space.Capacity;
    existingSpace.PricePerHour = space.PricePerHour;
    ctx.Spaces.Update(existingSpace);
    ctx.SaveChanges();
    return Results.Ok(existingSpace);
});

app.MapDelete("/spaces/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
        Spaces? spaceToRemove = ctx.Spaces.Find(id);
        if (spaceToRemove != null)
        {
            ctx.Spaces.Remove(spaceToRemove);
            ctx.SaveChanges();
        }
});

app.MapGet("/bookings", ([FromServices] AppDataContext ctx) =>
{
    if(ctx.Booking.Any())
    {
        return Results.Ok(ctx.Booking.ToList());
    }
    return Results.NotFound();
});

app.MapGet("/bookings/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    Booking? booking = ctx.Booking.Find(id);

    if (booking == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(booking);
});

app.MapPost("/bookings", ([FromServices] AppDataContext ctx, [FromBody] Booking booking) =>
{
    ctx.Booking.Add(booking);
    ctx.SaveChanges();
    return Results.Created();
});

app.MapPut("/bookings/{id}", ([FromServices] AppDataContext ctx, [FromBody] Booking booking) =>
{
    Booking? existingBooking = ctx.Booking.Find(id);
    if (existingBooking == null)
    {
        return Results.NotFound();
    }
    existingBooking.Name = booking.Name;
    existingBooking.Capacity = booking.Capacity;
    existingBooking.PricePerHour = booking.PricePerHour;
    ctx.Booking.Update(existingBooking);
    ctx.SaveChanges();
    return Results.Ok(existingBooking);
});

app.MapDelete("/bookings/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    Booking? booking = ctx.Booking.Find(id);
    
    if (booking == null)
    {
        return Results.NotFound();
    }

    ctx.Booking.Remove(booking);
    ctx.SaveChanges();
    return Results.Ok(booking);
});

app.MapGet("/payment", ([FromServices] AppDataContext ctx) =>
{

});

app.MapGet("/payment/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{});

app.MapPost("/payment/{id}", ([FromServices] AppDataContext ctx, [FromBody] Payment payment) =>
{

});

app.MapPut("/payment/{id}", ([FromServices] AppDataContext ctx, [FromBody] Payment payment) =>
{

});

app.MapDelete("/payment/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{

});

app.MapGet("/kpi", ([FromServices] AppDataContext ctx) =>
{
});

app.MapPost("/login", ([FromServices] AppDataContext ctx, [FromBody] User user) =>
{
});


app.Run();