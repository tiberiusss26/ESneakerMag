using System;
namespace proiect.Models
{
	public class Purchase
	{
		public DateTime PurchaseDate { get; set; }
		public double FinalPrice { get; set; }

		public Guid OrderId { get; set; }
		public Order Order { get; set; }

		public Guid ShoeId { get; set; }
		public Shoe Shoe { get; set; }
	}
}

