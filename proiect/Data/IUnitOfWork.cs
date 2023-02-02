using System;
using proiect.Repositories.UserRepository;

namespace proiect.Data
{
	public interface IUnitOfWork
	{
        DataBaseContext Context { get; }
        IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}

