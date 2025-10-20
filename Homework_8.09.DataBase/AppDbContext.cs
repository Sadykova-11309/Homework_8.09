using Homework_8._09.DataBase.Configurations;
using Homework_8._09.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.DataBase
{
	public class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Position> Positions { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new RoleConfiguration());
			modelBuilder.ApplyConfiguration(new PositionConfiguration());

			modelBuilder.Entity<Role>()
				.HasData(
				new Role { Id = 1, Name = "admin" },
				new Role { Id = 2, Name = "user" }
			);

			modelBuilder.Entity<Position>()
				.HasData(
				new Position { Id = 1, Title = "Backend Developer" },
				new Position { Id = 2, Title = "Frontend Developer" },
				new Position { Id = 3, Title = "QA" },
				new Position { Id = 5, Title = "SEO" },
				new Position { Id = 6, Title = "Team Lead" }
			);

			base.OnModelCreating(modelBuilder);
		}
	}
}
