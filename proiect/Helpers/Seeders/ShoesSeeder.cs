using System;
using proiect.Data;
using proiect.Models;

namespace proiect.Helpers.Seeders
{
	public class ShoesSeeder
	{
		public readonly DataBaseContext _dataBaseContext;

		public ShoesSeeder(DataBaseContext dataBaseContext)
		{
			_dataBaseContext = dataBaseContext;
		}

		public void seedInitialShoes()
		{
            if (!_dataBaseContext.Shoes.Any())
            {
                var shoe1 = new Shoe
                {
                    ShoeName = "Retro 1 High OG Royal Blue",
                    Brand = "Jordan",
                    Price = 180,
                    Availability = true
                };

                var shoe2 = new Shoe
                {
                    ShoeName = "Yeezy 700 V1 WaveRunner",
                    Brand = "Adidas",
                    Price = 220,
                    Availability = true
                };

                _dataBaseContext.Add(shoe1);
                _dataBaseContext.Add(shoe2);

                _dataBaseContext.SaveChanges();
            }
        }
	}
}

