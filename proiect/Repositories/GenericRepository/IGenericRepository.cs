﻿using System;
namespace proiect.Repositories.GenericRepository
{
	public interface IGenericRepository<TEntity> where TEntity: class
	{
		Task<List<TEntity>> GetAll();

        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        Task<bool> SaveAsync();
    }
}

