using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using proiect.Data;
using proiect.Helpers.Attributes;
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
        public IUnitOfWork _unitOfWork;
		public IJwtUtils _jwtUtils;
		public IMapper _mapper;

		public UserService(IUserRepository userRepository, IJwtUtils jwtUtils, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_userRepository = userRepository;
            _unitOfWork = unitOfWork;
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

		public async Task CreateAdmin(UserRequestDTO newUser)
		{
			var newDBUser = _mapper.Map<User>(newUser);
            newDBUser.PasswordHash = BCryptNet.HashPassword(newUser.Password);
            newDBUser.Role = Role.Admin;

            await _userRepository.CreateAsync(newDBUser);
            await _userRepository.SaveAsync();
        }

        public async Task CreateNewClient(UserRequestDTO newUser)
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

        public async Task DeleteByUsernameAsync(string username)
        {
            var user =  _userRepository.FindByUsername(username);
            if (user == null)
                return;
            _userRepository.Delete(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<User>> GetAllClients()
        {
            return (List<User>)_userRepository.GetAllClientsAsync();
        }

        public async Task<List<User>> GetAllAdmins()
        {
            return (List<User>)_userRepository.GetAllAdminsAsync();
        }

    }
}

