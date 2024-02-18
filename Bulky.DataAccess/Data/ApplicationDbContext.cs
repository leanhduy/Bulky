using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		// Create DbSet (equivalent to tables in database)
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category { ID = 1, Name = "Action", DisplayedOrder = 1 },
				new Category { ID = 2, Name = "SciFi", DisplayedOrder = 2 },
				new Category { ID = 3, Name = "History", DisplayedOrder = 3 }
			);
		}
	}
}
