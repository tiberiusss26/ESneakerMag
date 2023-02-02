using System;
using proiect.Data;
using proiect.Helpers.JwtUtils;
using proiect.Repositories.ShoeRepository;
using proiect.Repositories.UserRepository;
using proiect.Services.ShoeService;
using proiect.Services.UserService;

namespace proiect.Helpers.Extensions
{
	public static class ServiceExtension
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IUnitOfWork, UnitOfWork>();
			services.AddTransient<IShoeRepository, ShoeRepository>();

			return services;
		}

		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IShoeService, ShoeService>();

			return services;
		}

		//public static IServiceCollection AddSeeders(this IServiceCollection services)
		//{
		//    services.AddTransient<StudentsSeeder>();

		//    return services;
		//}

		public static IServiceCollection AddUtils(this IServiceCollection services)
		{
			services.AddTransient<IJwtUtils, JwtUtils.JwtUtils>();

			return services;
		}

	}
}

