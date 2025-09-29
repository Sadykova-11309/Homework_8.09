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
		public int Id { get; set; }
		public string login { get; set; }
		public string password { get; set; }

		[Required]
		[RegularExpression("^[mf]$", ErrorMessage = "Поле 'sex' должно иметь значение 'm' или 'f'.")]
		public string sex { get; set; }
	}
}
