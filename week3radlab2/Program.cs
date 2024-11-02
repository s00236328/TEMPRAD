using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;
using week3radlab2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AdsDb>();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// CRUD operations for Ads

// GET all ads, including Categories and Seller
app.MapGet("/ads", async (AdsDb db) =>
     await db.Ads.Include(a => a.Categories)
                .Include(a => a.Seller)
                .ToListAsync());

// GET a specific ad by ID, including Categories and Seller
app.MapGet("/ads/{id}", async (int id, AdsDb db) =>
    await db.Ads.Include(a => a.Categories)
                .Include(a => a.Seller)
                .FirstOrDefaultAsync(a => a.AdId == id)
        is Ads ad
            ? Results.Ok(ad)
            : Results.NotFound());

// POST a new ad
app.MapPost("/ads", async (Ads ad, AdsDb db) =>
{
    // Ensure that the Seller and Categories exist
    var seller = await db.Sellers.FindAsync(ad.SellerID);
    var category = await db.Categories.FindAsync(ad.CategoryId);


    db.Ads.Add(ad);
    await db.SaveChangesAsync();

    return Results.Created($"/ads/{ad.AdId}", ad);
});

// PUT to update an existing ad
app.MapPut("/ads/{id}", async (int id, Ads updatedAd, AdsDb db) =>
{
    var ad = await db.Ads.FindAsync(id);

    if (ad is null) return Results.NotFound();

    var seller = await db.Sellers.FindAsync(updatedAd.SellerID);
    var category = await db.Categories.FindAsync(updatedAd.CategoryId);

    if (seller is null || category is null)
        return Results.BadRequest("Invalid Seller or Category");

    ad.Description = updatedAd.Description;
    ad.SellerID = updatedAd.SellerID;
    ad.CategoryId = updatedAd.CategoryId;
    ad.Seller = seller;
    ad.Categories = category;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

// DELETE an ad
app.MapDelete("/ads/{id}", async (int id, AdsDb db) =>
{
    var ad = await db.Ads.FindAsync(id);

    if (ad is null) return Results.NotFound();

    db.Ads.Remove(ad);
    await db.SaveChangesAsync();

    return Results.Ok(ad);
});

// CRUD operations for Categories

// GET all categories
app.MapGet("/categories", async (AdsDb db) =>
    await db.Categories.ToListAsync());

// POST a new category
app.MapPost("/categories", async (Categories category, AdsDb db) =>
{
    db.Categories.Add(category);
    await db.SaveChangesAsync();

    return Results.Created($"/categories/{category.CategoriesId}", category);
});

// CRUD operations for Sellers

// GET all sellers
app.MapGet("/sellers", async (AdsDb db) =>
    await db.Sellers.ToListAsync());

// POST a new seller
app.MapPost("/sellers", async (Seller seller, AdsDb db) =>
{
    db.Sellers.Add(seller);
    await db.SaveChangesAsync();

    return Results.Created($"/sellers/{seller.SellerId}", seller);
});

app.Run();
