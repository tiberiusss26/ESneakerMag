using System;
using AutoMapper;
using proiect.Models;
using proiect.Models.DTOs.ShoeDTO;
using proiect.Repositories.ShoeRepository;

namespace proiect.Services.ShoeService
{
	public class ShoeService: IShoeService
	{
		private readonly IShoeRepository _shoeRepository;
		private readonly IMapper _mapper;

		public ShoeService(IShoeRepository shoeRepository, IMapper mapper)
		{
			_shoeRepository = shoeRepository;
			_mapper = mapper;
		}

        public IEnumerable<ShoeDTO> GetShoeMappedByBrand(string brand)
        {
            IEnumerable<Shoe> shoes = (IEnumerable<Shoe>)_shoeRepository.GetByBrandAsync(brand);
            IEnumerable<ShoeDTO> shoesResult = shoes.Select(p => _mapper.Map<ShoeDTO>(p));
            return shoesResult;
        }

        public async Task<ShoeDTO> AddShoe(ShoeDTO shoe)
        {
            var shoeModel = _mapper.Map<Shoe>(shoe);
            var addedShoe = await _shoeRepository.AddShoe(shoeModel);
            return _mapper.Map<ShoeDTO>(addedShoe);
        }

        public async Task<ShoeDTO> UpdateShoe(ShoeDTO shoe,bool available)
        {
            var shoeModel = _mapper.Map<Shoe>(shoe);
            var updatedShoe = await _shoeRepository.UpdateShoe(shoeModel.Id,available);
            return _mapper.Map<ShoeDTO>(updatedShoe);
        }

        public async Task<ShoeDTO> DeleteShoe(Guid id)
        {
            var deletedShoe = await _shoeRepository.DeleteShoe(id);
            return _mapper.Map<ShoeDTO>(deletedShoe);
        }

        public async Task<ShoeDTO> GetShoe(Guid id)
        {
            return _mapper.Map<ShoeDTO>(await _shoeRepository.GetShoe(id));
        }
    }
}

