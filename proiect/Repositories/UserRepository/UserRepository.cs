using System;
using proiect.Data;
using proiect.Models;
using proiect.Models.Enums;
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

		public IEnumerable<User> GetAllClientsAsync()
		{
			var users = _table.ToList();
			return users.Where(x => x.Role == Role.NewClient || x.Role == Role.LoyalClient);
		}

        public IEnumerable<User> GetAllAdminsAsync()
        {
            var users = _table.ToList();
            return users.Where(x => x.Role == Role.Admin);
        }

    } 
}

