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
		public string login { get; set; }
		public string password { get; set; }

		[Required]
		[RegularExpression("^[mf]$", ErrorMessage = "Поле 'sex' должно иметь значение '0' для мужчины или '1' для женщины.")]
		public int sex { get; set; }
		public int RoleId { get; set; }
		public int PositionId { get; set; }
	}
}
