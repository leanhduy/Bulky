using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Bulky.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region DBContext service for differnt database providers
#region MSSQL
// Add DBContext service (Use the correct database service)
// NOTE: On n-tier application, add-migration command will be run on Web project, adding the --project option = DataAccess project
// .net cli command: dotnet ef migrations add <Name> --project <Data Layer Project>
// Package manager console: Add-Migration <Name> -Project <Data Layer Project>
// SQL SERVER
builder.Services.AddDbContext<ApplicationDbContext>(
		options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
	)
);
#endregion
#region PostgreSQL
// PostgreSQL
// builder.Services.AddDbContext<ApplicationDbContext>(
// 	options => options.UseNpgsql(
// 			builder.Configuration.GetConnectionString("PostgresConnection"),
// 			x => x.MigrationsAssembly("Bulky.DataAccess")
// 		)
// 	);
#endregion
#endregion

// Removed the option that require user to confirm email before they can log in (options => options.SignIn.RequireConfirmedAccount = true)
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options => {
	options.LoginPath = $"/Identity/Account/Login";
	options.LogoutPath = $"/Identity/Account/Logout";
	options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});



#region Repositories service 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

builder.Services.AddScoped<IEmailSender, EmailSender>();		// Email Sender

#region Identity Razor pages
builder.Services.AddRazorPages();
#endregion


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
app.UseAuthentication();	// Check if username & password correctly before moving on. Always before Authorization.
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}"
);
app.MapRazorPages();

app.Run();