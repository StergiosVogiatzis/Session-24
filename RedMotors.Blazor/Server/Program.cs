using Microsoft.AspNetCore.ResponseCompression;
using RedMotors.Database;
using RedMotors.Database.Repository;
using RedMotors.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<GarageContext>();
//builder.Services.AddRedMotorsDatabase();
builder.Services.AddTransient<IEntityRepo<Customer>, CustomerRepo>();
builder.Services.AddTransient<IEntityRepo<Car>, CarRepo>();
builder.Services.AddTransient<IEntityRepo<Manager>, ManagerRepo>();
builder.Services.AddTransient<IEntityRepo<ServiceTask>, ServiceTaskRepo>();
builder.Services.AddTransient<IEntityRepo<Transaction>, TransactionRepo>();
builder.Services.AddTransient<IEntityRepo<TransactionLine>, TransactionLinesRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
