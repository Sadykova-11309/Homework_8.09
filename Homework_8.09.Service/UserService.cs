using Homework_8._09.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8._09.Service
{
	public class UserService
	{
		private List<User> users = new();
		private int nextid = 1;


		public User Create(User user)
		{
			user.Id = nextid;
			nextid++;
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
	}
}
