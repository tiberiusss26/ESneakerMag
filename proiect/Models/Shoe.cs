using System;
using proiect.Models.Base;

namespace proiect.Models
{
	public class Shoe: BaseEntity
	{
		public string ShoeName { get; set; }
		public string Brand { get; set; }

		public int Size { get; set; }
		public float Price { get; set; }
		public bool Availability { get; set; } = true;

		public ICollection<Purchase> Purchases { get; set; }
	}
}

