using System;
using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.UserRepository
{
	public interface IUserRepository: IGenericRepository<User>
    {
		User FindByUsername(string username);

		IEnumerable<User> GetAllClientsAsync();

        IEnumerable<User> GetAllAdminsAsync();

    }
}

