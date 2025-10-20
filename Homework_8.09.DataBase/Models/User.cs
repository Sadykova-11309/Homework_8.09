using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.DataBase.Models
{
	public class User
	{
		public Guid Id { get; set; }
		public string login { get; set; }
		public string password { get; set; }
		public int sex { get; set; } // 0 - male; 1 - female;
		public int RoleId { get; set; }
		public Role Role { get; set; } = null!;
		public int PositionId { get; set; }
		public Position Position { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
