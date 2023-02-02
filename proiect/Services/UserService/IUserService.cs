using System;
using proiect.Models;
using proiect.Models.DTOs.UserDTO;

namespace proiect.Services.UserService
{
	public interface IUserService
	{
		UserResponseDTO Authenticate(UserRequestDTO user);

		User GetById(Guid id);

		Task CreateNewClient(UserRequestDTO newUser);

        Task CreateAdmin(UserRequestDTO newUser);

        Task DeleteByUsernameAsync(string username);

		Task<List<User>> GetAllClients();

		Task<List<User>> GetAllAdmins();
    }
}

