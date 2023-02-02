using System;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.ShoeRepository
{
	public class ShoeRepository: GenericRepository<Shoe>,IShoeRepository
	{
		public ShoeRepository(DataBaseContext context): base(context)
		{

		}

		public void OrderByPrice(bool descending)
		{
			if(descending == false)
			{
				var shoeOrderAscending = _table.OrderBy(x => x.Price);

				var shoeOrderAscending2 = from s in _table
										  orderby s.Price
										  select s;
			}
			else
			{
                var shoeOrderAscending = _table.OrderByDescending(x => x.Price);

                var shoeOrderAscending2 = from s in _table
                                          orderby s.Price descending
                                          select s;
            }
		}

        public async Task<IEnumerable<Shoe>> GetBySize(int size)
        {
			return await _context.Shoes
				.Include(s => s.ShoeName)
				.Where(s => s.Size == size)
				.ToListAsync();
        }

        public async Task<IEnumerable<Shoe>> GetByBrandAsync(string brand)
        {
            return await _context.Shoes
                .Include(s => s.ShoeName)
                .Where(s => s.Brand == brand)
                .ToListAsync();
        }

        public async Task<Shoe> AddShoe(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
            await _context.SaveChangesAsync();
            return shoe;
        }

        public async Task<Shoe> UpdateShoe(Guid id, bool available)
        {
            var shoe = await _context.Shoes.FindAsync(id);
            shoe.Availability = available;
            _context.Shoes.Update(shoe);
            await _context.SaveChangesAsync();
            return shoe;
        }

        public async Task<Shoe> DeleteShoe(Guid id)
        {
            var shoe = await _context.Shoes.FindAsync(id);
            _context.Shoes.Remove(shoe);
            await _context.SaveChangesAsync();
            return shoe;
        }

        public async Task<Shoe> GetShoe(Guid id)
        {
            return await _context.Shoes.FindAsync(id);
        }
    }
}
