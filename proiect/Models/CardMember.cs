using System;
using proiect.Models.Base;

namespace proiect.Models
{
	public class CardMember: BaseEntity
	{
		public DateTime CreationDate { get; set; }
		public int StorePoints { get; set; }
		public int SalePercentage { get; set; }

		public User Client { get; set; }

	}
}

