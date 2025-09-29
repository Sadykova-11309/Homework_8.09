using Homework_8._09.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.Service.Services
{
	public class UserService
	{
		private List<User> users = new();
		private int nextid = 1;


		public User Create(User user)
		{
			user.Id = nextid;
			nextid++;
			user.CreatedAt = DateTime.Now;
			users.Add(user);
			return user;

		}

		public User Update(User updatedUser)
		{
			var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
			if (user != null)
			{
				user.login = updatedUser.login;
				user.password = updatedUser.password;
				user.sex = updatedUser.sex;
				user.UpdatedAt = DateTime.Now;
			}
			return user;
		}

		public bool Delete (int id)
		{
			var user = users.FirstOrDefault(u => u.Id == id);
			if (user != null)
			{
				users.Remove(user);
				return true;
			}
			return false;
		}

		public User GetByCredentials (string login, string password)
		{
			return users.FirstOrDefault(u => u.login == login && u.password == password);
		}

		public List<User> GetAll ()
		{
			return users;
		}

		public List<User> GetByTimePeriodForCreated (DateTime beginingTime, DateTime endingTime)
		{
			return users.Where(u => u.CreatedAt >= beginingTime && u.CreatedAt <= endingTime).ToList();
		}

		public List<User> GetByTimePeriodForUpdated(DateTime beginingTime, DateTime endingTime)
		{
			return users.Where(u => u.UpdatedAt >= beginingTime && u.UpdatedAt <= endingTime).ToList();
		}


		//LINQ methods
		public List<User> GetSortedBySex(string sex)
		{
			return users.Where(u => u.sex  == sex).ToList();	
		}

		public int GetCount () { return users.Count; }

		public DateTime? GetMaxDateTime()
		{
			return users.Select(u => u.CreatedAt)
				.DefaultIfEmpty()
				.Max();
		}

		public DateTime? GetMinDateTime()
		{
			return users.Select(u => u.CreatedAt)
				.DefaultIfEmpty()
				.Min();
		}
	}
}
