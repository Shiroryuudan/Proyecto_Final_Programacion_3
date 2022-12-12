using Microsoft.EntityFrameworkCore;
using MJL_Ecommerce.Data;
using Microsoft.AspNetCore.Identity;
using MJL_Ecommerce.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ECommerceDbContextcs");
builder.Services.AddDbContext<ECommerceDbContextcs>(x => x.UseSqlServer(connectionString));

var connectionString2 = builder.Configuration.GetConnectionString("LoginMJL_EcommerceContext");
builder.Services.AddDbContext<LoginMJL_EcommerceContext>(x => x.UseSqlServer(connectionString2));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LoginMJL_EcommerceContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();



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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
}

);
app.Run();
