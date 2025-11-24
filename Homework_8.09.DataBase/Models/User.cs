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
		public string Login { get; set; }
		public string Password { get; set; }
		public int Sex { get; set; } // 0 - male; 1 - female;
		public int RoleId { get; set; }
		public Role Role { get; set; } = null!;
		public int PositionId { get; set; }
		public Position Position { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
