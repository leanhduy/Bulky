using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DBContext service (Use the corrent database service)

// NOTE: On n-tier application, add-migration command will be run on Web project, adding the --project option = DataAccess project
// .net cli command: dotnet ef migrations add <Name> --project <Data Layer Project>
// Package manager console: Add-Migration <Name> -Project <Data Layer Project>
// SQL SERVER
builder.Services.AddDbContext<ApplicationDbContext>(
		options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
	)
);

// PostgreSQL
// builder.Services.AddDbContext<ApplicationDbContext>(
// 	options => options.UseNpgsql(
// 			builder.Configuration.GetConnectionString("PostgresConnection"),
// 			x => x.MigrationsAssembly("Bulky.DataAccess")
// 		)
// 	);

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

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
