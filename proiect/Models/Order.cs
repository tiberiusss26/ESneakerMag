using System;
using proiect.Models.Base;

namespace proiect.Models
{
	public class Order: BaseEntity
	{
		public string Description { get; set; }
		public bool IsConfirmed { get; set; }

		public User? Client { get; set; }

		public ICollection<Purchase> Purchases { get; set; }		
	}
}

