using System;
using System.ComponentModel.DataAnnotations;

namespace proiect.Models.DTOs.UserDTO
{
	public class UserRequestDTO
	{

		public string FirstName { get; set; }

		public string LastName { get; set; }

		[Required]
		 
		public string Email { get; set; }

		[Required]

		public string Username { get; set; }

		[Required]	

		public string PasswordHash { get; set; }

	}
}

