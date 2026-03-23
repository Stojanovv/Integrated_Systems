using EventMenagement.Repository.Interface;
using EventMenagement.Service;
using EventMenagement.Service.implemetation;
using EventMenagement.Service.implemetation.Interceptor;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EventMenagement.Web.Data;
using EventMenagement.Web.mapper;
using EventsManagement.Repository.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

app.MapRazorPages()
    .WithStaticAssets();

//Repository -Scoped (open generic registration)
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

//Services - Scoped
builder.Services.AddScoped<IEventService,EventService>();
builder.Services.AddScoped<ISeatService, SeatService>();

//Mappers - Scoped
builder.Services.AddScoped<EventMapper>();
builder.Services.AddScoped<SeatMapper>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUser, CurrentUser>();

builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    options.AddInterceptors(sp.GetRequiredService<AuditInterceptor>());
});
app.Run();