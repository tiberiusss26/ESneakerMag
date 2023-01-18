using System;
using proiect.Models.DTOs.UserDTO;

namespace proiect.Services.UserService
{
	public interface IUserService
	{
		UserResponseDTO Authenticate(UserRequestDTO user);

		UserRequestDTO GetById(Guid id);

		Task  Create(UserRequestDTO newUser);
	}
}

