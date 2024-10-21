var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
    if(ctx.Users.Any())
    {
        return Results.Ok(ctx.Users.Tolist());
    }
    return Results.NotFound();
});

app.MapGet("/user/:id", ([FromServices] AppDataContext ctx) =>
{
    User? user = ctx.User.Find(id);

    if (user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);
});

app.UserPost("/user", ([FromServices] AppDataContext ctx) =>
{
    ctx.Users.Add(user);
    ctx.SaveChanges();
    return Results.Created();
});

app.MapPut("/users/:id", ([FromServices] AppDataContext ctx) =>
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
    ctx.Users.Update(user);
    ctx.SaveChanges();
    return Results.Ok(user);
});

app.MapDelete("/users/:id", ([FromServices] AppDataContext ctx) =>
{
    User? user = ctx.User.Find(id);
    
    if (user == null)
    {
        return Results.NotFound();
    }

    ctx.Users.Remove(user);
    ctx.SaveChanges();
    return Results.Ok(user);
});

app.MapGet("/spaces", ([FromServices] AppDataContext ctx) =>
{
    if(ctx.Users.Any())
    {
        return Results.Ok(ctx.Spaces.Tolist());
    }
    return Results.NotFound();
});

app.MapGet("/spaces/:id", ([FromServices] AppDataContext ctx) =>
{
    User? user = ctx.Spaces.Find(id);

    if (user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(user);
});

app.MapPost("/spaces", ([FromServices] AppDataContext ctx) =>
{
    ctx.Spaces.Add(space);
    ctx.SaveChanges();
    return Results.Created();
});

app.MapPut("/spaces/:id", ([FromServices] AppDataContext ctx) =>
{
    Space? existingSpace = ctx.Space.Find(id);
    if (user == null)
    {
        return Results.NotFound();
    }
    existingSpace.Name = space.Name;
    existingSpace.Capacity = space.Capacity;
    existingSpace.PricePerHour = space.PricePerHour;
    ctx.Users.Update(user);
    ctx.SaveChanges();
    return Results.Ok(user);
});

app.MapDelete("/spaces/:id", ([FromServices] AppDataContext ctx) =>
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
})

app.MapGet("/bookings/:id", ([FromServices] AppDataContext ctx) =>
{
    Bookings? bookings = ctx.Bookings.Find(id);

    if (bookings == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(bookings);
})

app.MapPost("/bookings", ([FromServices] AppDataContext ctx) =>
{
    ctx.Bookings.Add(bookings);
    ctx.SaveChanges();
    return Results.Created();
})

app.MapPut("/bookings/:id", ([FromServices] AppDataContext ctx) =>
{
    BookingsService.update()
})

app.MapDelete("/bookings/:id", ([FromServices] AppDataContext ctx) =>
{
    Bookings? bookings = ctx.Bookings.Find(id);
    
    if (bookings == null)
    {
        return Results.NotFound();
    }

    ctx.Bookings.Remove(bookings);
    ctx.SaveChanges();
    return Results.Ok(bookings);
})

app.MapGet("/payment", ([FromServices] AppDataContext ctx) =>
{
    PaymentService.getAll();
});

app.MapGet("/payment/:id", ([FromServices] AppDataContext ctx) =>
{
    PaymentService.getById();
});

app.MapPost("/payment/:id", ([FromServices] AppDataContext ctx) =>
{
    PaymentService.create();
});

app.MapPut("/payment/:id", ([FromServices] AppDataContext ctx) =>
{
    PaymentService.update();
});

app.MapDelete("/payment/:id", ([FromServices] AppDataContext ctx) =>
{
    PaymentService.delete();
});

app.MapGet("/kpi", ([FromServices] AppDataContext ctx) =>
{
});


app.MapPost("/login", ([FromServices] AppDataContext ctx) =>
{
});


app.Run();