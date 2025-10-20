using Homework_8._09.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.DataBase.Repository.Extensions
{
	public interface IUserRepository
	{
		Task<User> CreateAsync(User user);
		Task<User> UpdateAsync(User updatedUser);
		Task<bool> DeleteAsync(Guid Id);
		Task<List<User>> GetAllAsync();
		Task<User> GetByCredentialsAsync(string login, string password);
		Task<List<User>> GetByTimePeriodForCreatedAsync(DateTime beginingTime, DateTime endingTime);
		Task<List<User>> GetByTimePeriodForUpdatedAsync(DateTime beginingTime, DateTime endingTime);
		Task<List<User>> SortedBySexAsync(int sex);
		Task<int> GetCountAsync();
		Task<DateTime?> GetMaxCreatedAtAsync();
		Task<DateTime?> GetMinCreatedAtAsync();
		Task<User> GetByIdAsync(Guid Id);
		Task<bool> ExistsAsync(Guid Id);
		Task<User> GetByLoginAsync(string login);
	}
}
