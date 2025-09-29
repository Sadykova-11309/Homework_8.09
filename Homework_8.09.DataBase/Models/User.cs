using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.DataBase.Models
{
	public class User
	{
		public int Id { get; set; }
		public string login { get; set; }
		public string password { get; set; }
		public string sex { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
