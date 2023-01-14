using System;
using System.Text.Json.Serialization;
using proiect.Models.Base;
using proiect.Models.Enums;

namespace proiect.Models
{
	public class User: BaseEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Email { get; set; }
		public string Username { get; set; }
		public Role Role { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

		public ICollection<Order> Orders { get; set; }

		public CardMember CardMember { get; set; }
		public Guid CardMemberId { get; set; }
    }
}

