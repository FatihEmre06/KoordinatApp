using Microsoft.EntityFrameworkCore;
using MapApplication.Models;

namespace MapApplication
{
	public class PointDbContext : DbContext
	{
		public DbSet<CustomPoint> Points { get; set; }

		public PointDbContext(DbContextOptions<PointDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CustomPoint>().ToTable("points");
			modelBuilder.Entity<CustomPoint>().Property(p => p.Id).HasColumnName("id");
			modelBuilder.Entity<CustomPoint>().Property(p => p.WKT).HasColumnName("wkt");
			modelBuilder.Entity<CustomPoint>().Property(p => p.Name).HasColumnName("name");
		}
	}
}