using Microsoft.EntityFrameworkCore;
using HDD.Infrastructure.Identity;
using HDD.Infrastructure.Data;
using HDD.Infrastructure.Services;
using HDD.Web.Attributes;
using HDD.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<HDDDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HDDDbContext")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("HDDDbContext")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));;

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();;

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(ValidateModelStateAttribute));
});

builder.Services.AddAntiforgery(options =>
{
    //options.FormFieldName = "Input.__RequestVerificationToken";
    options.HeaderName = "XSRF-TOKEN";
});
builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<IHDDRepository, HDDRepository>();
//builder.Services.AddTransient<IEmailService, EmailService>();
//builder.Services.AddTransient<IFileUploadService, FileUploadService>();
//builder.Services.AddTransient<IVinOwnershipService, VinOwnershipService>();
//builder.Services.AddTransient<IVinService, VinService>();
//builder.Services.AddTransient<IEmailSender, EmailSender>();
//var app = builder.Build();

builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection("EmailOptions"));
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddWebServices(builder.Configuration);

// Add memory cache services
builder.Services.AddMemoryCache();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
