using Homework_8._09.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.DataBase.Configurations
{
	public class PositionConfiguration : IEntityTypeConfiguration<Position>
	{
		public void Configure(EntityTypeBuilder<Position> builder)
		{
			builder.HasKey(r => r.Id);
			builder.Property(r => r.Title).IsRequired().HasMaxLength(50);
		}
	}
}
