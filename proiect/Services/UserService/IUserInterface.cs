using System;
using proiect.Models.DTOs.UserDTO;

namespace proiect.Services.UserService
{
	public interface IUserInterface
	{
		UserResponseDTO Authenticate(UserRequestDTO user);

		UserRequestDTO GetById(Guid id);

		Task  Create(UserRequestDTO newUser);
	}
}

