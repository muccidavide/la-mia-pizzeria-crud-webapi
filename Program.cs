using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_static.Data;
using System.Text.Json.Serialization;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PizzaContextConnection") ?? throw new InvalidOperationException("Connection string 'PizzaContextConnection' not found.");

builder.Services.AddDbContext<PizzaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<PizzaContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// inizio codice da inserire
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
// fine codice da inserire

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddRazorPages()
    .AddMvcOptions(options =>
    {
        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
            _ => "Il campo ? richiesto.");
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

app.UseAuthentication();

app.UseAuthorization();

/*app.MapControllerRoute(
       name: "default",
       pattern: "~/api/{controller}/{action}/{id?}",
       new { controller = "Home", action = "Index" });*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
