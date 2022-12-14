using EmployeesMVC.Contexts;
using EmployeesMVC.Repositories.Implementations;
using EmployeesMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmployeesContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
