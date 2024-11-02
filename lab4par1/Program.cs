using Microsoft.EntityFrameworkCore;
using lab4_1;

var builder = WebApplication.CreateBuilder(args); 
var connectionString = builder.Configuration.GetConnectionString("todo") ?? "Data Source=todo.db";
builder.Services.AddSqlite<TodoDb>(connectionString);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();


var todoItems = app.MapGroup("/todoitems");

todoItems.MapGet("/", async (TodoDb db) =>
    await db.Todos.ToListAsync());

// Using a route parameter
todoItems.MapGet("/BillingType/{billingType}", async (TodoDb db, BillingType billingType) =>
    await db.Todos.Where(t => t.BT == billingType).ToListAsync());


todoItems.MapGet("/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());

todoItems.MapGet("/{priority:int}", async (int priority, TodoDb db) =>
{
    return await db.Todos.Where(t => t.priority == priority).ToListAsync();
});

todoItems.MapPost("/", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

todoItems.MapPut("/{id}", async (int id, Todo inputTodo, TodoDb db ) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.BT = inputTodo.BT;
    todo.priority = inputTodo.priority;
    await db.SaveChangesAsync();

    return Results.NoContent();
});


todoItems.MapDelete("/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();