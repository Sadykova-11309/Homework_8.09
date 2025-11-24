using Homework_8._09.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.DataBase.Configurations
{
	internal class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasIndex(u => u.Login).IsUnique();

			builder.HasOne(u => u.Role)
			   .WithMany()
			   .HasForeignKey(u => u.RoleId)
			   .OnDelete(DeleteBehavior.Restrict);
		}
	}
}
