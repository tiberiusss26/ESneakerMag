using System;
using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.ShoeRepository
{
	public interface IShoeRepository: IGenericRepository<Shoe>
	{
        public void OrderByPrice(bool descending);
        Task<IEnumerable<Shoe>> GetBySize(int size);
        Task<IEnumerable<Shoe>> GetByBrandAsync(string brand);
        Task<Shoe> UpdateShoe(Guid id, bool available);
        Task<Shoe> AddShoe(Shoe shoe);
        Task<Shoe> DeleteShoe(Guid id);
        Task<Shoe> GetShoe(Guid id);
    }
}

