using EventMenagement.Repository.Interface;
using EventMenagement.Service;
using EventMenagement.Service.implemetation;
using EventMenagement.Service.implemetation.Interceptor;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EventMenagement.Web.Data;
using EventMenagement.Web.mapper;
using EventsManagement.Repository.Implementation;
using EvolveDb;
using Microsoft.Data.Sqlite;
using EventMenagement.Repository;
using ApplicationDbContext = EventMenagement.Repository.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);

// Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Register AuditInterceptor
builder.Services.AddScoped<AuditInterceptor>();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    options.UseSqlite(connectionString);
    options.UseLazyLoadingProxies();

    // Inject interceptor correctly
    var interceptor = sp.GetRequiredService<AuditInterceptor>();
    options.AddInterceptors(interceptor);
});

// Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Repository, Services, Mappers
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped<EventMapper>();
builder.Services.AddScoped<SeatMapper>();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Evolve migration
using var cnx = new SqliteConnection(connectionString);
cnx.Open(); // Sqlite needs connection open for Evolve
var evolve = new Evolve(cnx, msg => Console.WriteLine(msg))
{
    Locations = new[] { "Database/migrations" },
    IsEraseDisabled = true
};
evolve.Migrate();

// HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages().WithStaticAssets();

app.Run();