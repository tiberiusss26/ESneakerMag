using System;
using proiect.Data;
using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.UserRepository
{
	public class UserRepository: GenericRepository<User>, IUserRepository
	{
		public UserRepository(DataBaseContext context): base(context) { }

		public User FindByUsername(string username)
		{
			return _table.FirstOrDefault(u => u.Username == username);
		}
	} 
}

