using Microsoft.EntityFrameworkCore;
using week3radlab2;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
