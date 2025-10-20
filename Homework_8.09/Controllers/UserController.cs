using AutoMapper;
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

		public UserController(UserService userService, IMapper mapper)
		{
			_userService = userService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] CreateRequest request)
		{
			var newUser = await _userService.Create(request); 
			return Ok(newUser); 
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest request)
		{
			var user = await _userService.GetByCredentials(request);
			if (user == null)
			{
				return Unauthorized(new { Message = "Пользователь не авторизован!" });
			}

			return Ok(new
			{
				Message = "Пользователь авторизован!",
				User = user
			});
		}

		[HttpPut("update/{Id}")]
		public async Task<IActionResult> Update(Guid Id, [FromBody] UpdateRequest request)
		{
			var updatedUser = await _userService.Update(Id, request);

			if (updatedUser == null)
			{
				return NotFound(new { Message = "Пользователь не найден!" });
			}

			return Ok(updatedUser);
		}

		[HttpDelete("delete/{Id}")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var result = await _userService.Delete(Id);
			if (!result) { return NotFound(new { Message = "Пользователь не найден!" }); }
			return Ok(new { Message = "Пользователь удален!" });
		}

		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			var users = await _userService.GetAll();
			return Ok(users);
		}

		[HttpGet("created-time-filter")]
		public async Task<IActionResult> GetCreatedByPeriod([FromQuery] DateTime beginingTime, [FromQuery] DateTime endingTime)
		{
			if (beginingTime > endingTime) { return BadRequest("Начальное время не может быть больше конечного"); }
			var users = await _userService.GetByTimePeriodForCreated(beginingTime, endingTime);
			return Ok(users);
		}

		[HttpGet("updated-time-filter")]
		public async Task<IActionResult> GetUpdatedByPeriod([FromQuery] DateTime beginingTime, [FromQuery] DateTime endingTime)
		{
			if (beginingTime > endingTime) { return BadRequest("Начальное время не может быть больше конечного"); }
			var users = await _userService.GetByTimePeriodForUpdated(beginingTime, endingTime);
			return Ok(users);
		}

		//Controller for LINQ methods

		[HttpGet("users-count")]
		public async Task<IActionResult> GetUsersCount()
		{	
		    var count = await _userService.GetCount();
			return Ok(count);
		}

		[HttpGet("sort-users-by-sex")]
		public async Task<IActionResult> GetSortedUsers(int sex)
		{
			if (sex != 0 &&  sex != 1)
			{
				return BadRequest("Поле 'sex' должно иметь значение '0' или '1'");
			}
			var users =  await _userService.GetSortedBySex(sex);
			return Ok(users);
		}

		[HttpGet("max-registration-date")]
		public async Task<IActionResult> GetMaxDate()
		{
			var date = await _userService.GetMaxDateTime();
			return Ok(date);
		}

		[HttpGet("min-registration-date")]
		public async Task<IActionResult> GetMinDate()
		{
			var date = await _userService.GetMinDateTime();
			return Ok(date);
		}
	}
}
