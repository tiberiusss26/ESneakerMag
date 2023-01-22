using System;
using AutoMapper;
using NuGet.DependencyResolver;
using proiect.Helpers.JwtUtils;
using proiect.Models;
using proiect.Models.DTOs.UserDTO;
using proiect.Models.Enums;
using proiect.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;
namespace proiect.Services.UserService
{
	public class UserService: IUserService
	{
		public IUserRepository _userRepository;
		public IJwtUtils _jwtUtils;
		public IMapper _mapper;

		public UserService(IUserRepository userRepository, IJwtUtils jwtUtils, IMapper mapper)
		{
			_userRepository = userRepository;
			_jwtUtils = jwtUtils;
			_mapper = mapper;
		}

		public UserResponseDTO Authenticate(UserRequestDTO model)
		{
			var user = _userRepository.FindByUsername(model.Username);
			if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash)) {
				return null;
			}

			var jwtToken = _jwtUtils.GenerateJwtToken(user);
			return new UserResponseDTO(user, jwtToken);
		}
		public async Task Create(UserRequestDTO newUser)
		{
			var newDBUser = _mapper.Map<User>(newUser);
            newDBUser.PasswordHash = BCryptNet.HashPassword(newUser.Password);
            newDBUser.Role = Role.NewClient;

            await _userRepository.CreateAsync(newDBUser);
            await _userRepository.SaveAsync();
        }

        public User GetById(Guid id)
        {
			return _userRepository.FindById(id);
        }
    }
}

