using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.Models.DTO
{
	public class UpdateRequest
	{
		public Guid Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public int Sex { get; set; }
		public int RoleId { get; set; }
		public int PositionId { get; set; }
	}
}
