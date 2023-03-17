using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using shopProject.Interface;
using shopProject.Models;
using shopProject.SQLRepository;
using shopProject.ViewModels;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<ICustomerRepository, CustomersSQLRepository>();
builder.Services.AddScoped<IOrderRepository, OrdersSQLRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemsSQLRepository>();
builder.Services.AddScoped<IProductRepository, ProductsSQLRepository>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    //options.Password.RequiredUniqueChars = 3;
}).AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DeleteRolePolicy",
        policy => policy.RequireClaim("Delete Role"));

    options.AddPolicy("EditRolePolicy",
    policy => policy.RequireClaim("Edit Role", "true")
                    .RequireRole("admin"));

    options.AddPolicy("AdminRolePolicy",
        policy => policy.RequireRole("admin"));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = new PathString("/Administration/AccessDenied");
});

//builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testdb;Trusted_Connection=True;"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();