using Homework_8._09.DataBase.Models;
using Homework_8._09.DataBase.Repository.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Homework_8._09.DataBase.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _context;
		public UserRepository (AppDbContext context)
		{
			_context = context;
		}
		public async Task<User> CreateAsync(User user)
		{
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
			await LoadNavigationProperties(user);
			return user;
		}

		public async Task<bool> DeleteAsync(Guid Id)
		{
			var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);
			if(user != null)
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<bool> ExistsAsync(Guid Id)
		{
			return await _context.Users.AnyAsync(u => u.Id == Id);
		}

		public async Task<List<User>> GetAllAsync()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task<User> GetByIdAsync(Guid Id)
		{
			return await _context.Users.FirstOrDefaultAsync(u =>u.Id == Id);	
		}

		public async Task<User> GetByCredentialsAsync(string login, string password)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
		}

		public async Task<User> GetByLoginAsync(string login)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
		}

		public async Task<List<User>> GetByTimePeriodForCreatedAsync(DateTime beginingTime, DateTime endingTime)
		{
			return await _context.Users.Where(u => u.CreatedAt >= beginingTime && u.CreatedAt <= endingTime).ToListAsync();
		}

		public async Task<List<User>> GetByTimePeriodForUpdatedAsync(DateTime beginingTime, DateTime endingTime)
		{
			return await _context.Users.Where(u => u.UpdatedAt >= beginingTime && u.UpdatedAt <= endingTime).ToListAsync();
		}

		public async Task<int> GetCountAsync()
		{
			return await _context.Users.CountAsync();
		}

		public async Task<DateTime?> GetMaxCreatedAtAsync()
		{
			return await _context.Users.Select(u => u.CreatedAt).DefaultIfEmpty().MaxAsync();
		}

		public async Task<DateTime?> GetMinCreatedAtAsync()
		{
			return await _context.Users.Select(u => u.CreatedAt).DefaultIfEmpty().MaxAsync();
		}

		public async Task<List<User>> SortedBySexAsync(int sex)
		{
			return await _context.Users.Where(u => u.Sex == sex).ToListAsync();
		}

		public async Task<User> UpdateAsync(User updatedUser)
		{
			var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
			if (user == null)
				return null;

			user.Login = updatedUser.Login;
			user.Password = updatedUser.Password;
			user.Sex = updatedUser.Sex;
			user.RoleId = updatedUser.RoleId;        
			user.PositionId = updatedUser.PositionId;

			await _context.SaveChangesAsync();
			await LoadNavigationProperties(user);
			return user;
		}

		private async Task LoadNavigationProperties(User user)
		{
			await _context.Entry(user).Reference(u => u.Role).LoadAsync();
			await _context.Entry(user).Reference(u => u.Position).LoadAsync();
		}

	}
}
