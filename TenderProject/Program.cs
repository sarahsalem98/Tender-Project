using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TenderProject.Data;
using TenderProject.Helpers;
using TenderProject.Models;
using TenderProject.Repository;
using TenderProject.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented=true;
    })
    .AddRazorRuntimeCompilation() 
    ;

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<Auth>();




builder.Services.AddAuthentication(a =>
{ a.DefaultScheme = "Supplier_Schema"; }
).AddCookie("Supplier_Schema", options =>
{
    options.Cookie.Name = "Supplier";
}

).AddCookie("Admin_Schema", options =>
{
    options.Cookie.Name = "Admin";
}
);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", AuthBuilder =>
    {
        AuthBuilder.AddAuthenticationSchemes("Admin_Schema");
        AuthBuilder.RequireRole("Admin");

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name:"Admin",
    areaName:"Admin",
    pattern:"admin/{controller=Account}/{action=Login}/{id?}/{returnUrl?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
