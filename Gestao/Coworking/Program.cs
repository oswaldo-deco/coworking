using Coworking.Models;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

app.UseHttpsRedirection();


app.UseCors("AllowAllOrigins");

app.MapGet("/", () => "API está funcionando!");



app.UseHttpsRedirection();

app.MapGet("/", () => "API está funcionando!");


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
    return Results.Created($"/user/{user.Id}", user);
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
    userFound.TaxNumber = userAlterado.TaxNumber;
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
    ctx.SaveChangesAsync();
    return Results.Ok(user);
});

app.MapGet("/spaces", ([FromServices] AppDataContext ctx) =>
{
    if(ctx.Spaces.Any())
    {
        return Results.Ok(ctx.Spaces.ToList());
    }
    return Results.NotFound();
});

app.MapGet("/spaces/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
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
    return Results.Created($"/spaces/{space.Id}", space);
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
    return Results.Created($"/bookings/{booking.Id}", booking);
});

app.MapPut("/bookings/{id}", ([FromServices] AppDataContext ctx, [FromBody] Booking booking, [FromRoute] string id) =>
{
    Booking? existingBooking = ctx.Booking.Find(id);
    if (existingBooking == null)
    {
        return Results.NotFound();
    }
    existingBooking.User = booking.User;
    existingBooking.CriadoEm = booking.CriadoEm;
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
    if(ctx.Payment.Any())
    {
        return Results.Ok(ctx.Payment.ToList());
    }
    return Results.NotFound();
});

app.MapGet("/payment/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    Payment? payment = ctx.Payment.Find(id);

    if (payment == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(payment);
});

app.MapPost("/payment", ([FromServices] AppDataContext ctx, [FromBody] Payment payment) =>
{
    ctx.Payment.Add(payment);
    ctx.SaveChanges();
    return Results.Created($"/payment/{payment.Id}", payment);
});

app.MapPut("/payment/{id}", ([FromServices] AppDataContext ctx, [FromBody] Payment payment, [FromRoute] string id) =>
{
    Payment? existingPayment = ctx.Payment.Find(id);
    if (existingPayment == null)
    {
        return Results.NotFound();
    }
    existingPayment.UserId = payment.UserId;
    existingPayment.SpaceId = payment.SpaceId;
    existingPayment.Valor = payment.Valor;
    existingPayment.Status = payment.Status;
    ctx.Payment.Update(existingPayment);
    ctx.SaveChanges();
    return Results.Ok(existingPayment);
});

app.MapDelete("/payment/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    Payment? payment = ctx.Payment.Find(id);
    
    if (payment == null)
    {
        return Results.NotFound();
    }

    ctx.Payment.Remove(payment);
    ctx.SaveChanges();
    return Results.Ok(payment);
});

app.MapPost("/login", ([FromServices] AppDataContext ctx, [FromBody] User user) =>
{
    string Email = user.Email;
    User userInDatabase = ctx.User.Find(Email);
    if(user.Password == userInDatabase.Password){
        return Results.Ok();
    }

    return Results.Unauthorized();
});


app.Run();