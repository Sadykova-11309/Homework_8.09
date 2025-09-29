using Homework_8._09.DataBase.Models;
using Homework_8._09.DataBase.Scheme;
using Homework_8._09.Models.DTO;
using Homework_8._09.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;


namespace Homework_8._09.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserService _userService;

		public UserController(UserService userService)
		{
			_userService = userService;
		}

		[HttpPost("register")]
		public IActionResult Register([FromBody] CreateRequest request)
		{
			var user = new User
			{
				login = request.login,
				password = request.password,
				sex = request.sex
			};
			var newUser = _userService.Create(user); 
			return Ok(newUser);
		}

		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginRequest request)
		{
			var user = _userService.GetByCredentials(request.login, request.password);
			if (user == null) { return Unauthorized(new { Message = "Пользователь не авторизован!" }); }
			return Ok(new { Message = "Пользователь авторизован!" });
		}

		[HttpPut("update")]
		public IActionResult Update([FromBody] UpdateRequest request)
		{
			var user = new User
			{
				Id = request.Id,
				login = request.login,
				password = request.password,
				sex = request.sex
			};
			var updatedUser = _userService.Update(user);
			if (updatedUser == null) { return NotFound(new { Message = "Пользователь не найден!" }); }
			return Ok(updatedUser);
		}

		[HttpDelete("delete/{id}")]
		public IActionResult Delete(int id)
		{
			var result = _userService.Delete(id);
			if (!result) { return NotFound(new { Message = "Пользователь не найден!" }); }
			return Ok(new { Message = "Пользователь удален!" });
		}

		[HttpGet("all")]
		public IActionResult GetAll()
		{
			var users = _userService.GetAll();
			return Ok(users);
		}

		[HttpGet("created time filter")]
		public IActionResult GetCreatedByPeriod([FromQuery] DateTime beginingTime, [FromQuery] DateTime endingTime)
		{
			if (beginingTime > endingTime) { return BadRequest("Начальное время не может быть больше конечного"); }
			var users = _userService.GetByTimePeriodForCreated(beginingTime, endingTime);
			return Ok(users);
		}

		[HttpGet("updated time filter")]
		public IActionResult GetUpdatedByPeriod([FromQuery] DateTime beginingTime, [FromQuery] DateTime endingTime)
		{
			if (beginingTime > endingTime) { return BadRequest("Начальное время не может быть больше конечного"); }
			var users = _userService.GetByTimePeriodForUpdated(beginingTime, endingTime);
			return Ok(users);
		}

		//Controller for LINQ methods

		[HttpGet("users count")]
		public IActionResult GetUsersCount()
		{
			var count = _userService.GetCount();
			return Ok(count);
		}

		[HttpGet("sort users by sex")]
		public IActionResult GetSortedUsers(string sex)
		{
			if (sex != "m" &&  sex != "f")
			{
				return BadRequest("Поле 'sex' должно иметь значение 'm' или 'f'");
			}
			var users = _userService.GetSortedBySex(sex);
			return Ok(users);
		}

		[HttpGet("max registration date")]
		public IActionResult GetMaxDate()
		{
			var date = _userService.GetMaxDateTime();
			return Ok(date);
		}

		[HttpGet("min registration date")]
		public IActionResult GetMinDate()
		{
			var date = _userService.GetMinDateTime();
			return Ok(date);
		}
	}
}
