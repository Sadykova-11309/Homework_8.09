using Homework_8._09.DataBase;
using Homework_8._09.Service;
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
		public IActionResult Register([FromBody] User user)
		{
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
		public IActionResult Update([FromBody] User user)
		{
			var updatedUser = _userService.Update(user);
			if (updatedUser == null) { return NotFound(new { Message = "Пользователь не найден!" }); }
			return Ok(updatedUser);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var result = _userService.Delete(id);
			if (!result) { return NotFound(new { Message = "Пользователь не найден!" }); }
			return Ok(new { Message = "Пользователь удален!" });
		}
	}
}
