using System;
using proiect.Models;
using proiect.Models.DTOs.UserDTO;

namespace proiect.Services.UserService
{
	public interface IUserService
	{
		UserResponseDTO Authenticate(UserRequestDTO user);

		User GetById(Guid id);

		Task  Create(UserRequestDTO newUser);
	}
}

