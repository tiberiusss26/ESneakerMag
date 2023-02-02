using System;
using proiect.Models.DTOs.ShoeDTO;

namespace proiect.Services.ShoeService
{
	public interface IShoeService
	{
        IEnumerable<ShoeDTO> GetShoeMappedByBrand(string brand);
        Task<ShoeDTO> AddShoe(ShoeDTO shoe);
        Task<ShoeDTO> UpdateShoe(ShoeDTO shoe, bool available);
        Task<ShoeDTO> DeleteShoe(Guid id);
        Task<ShoeDTO> GetShoe(Guid id);
    }
}

