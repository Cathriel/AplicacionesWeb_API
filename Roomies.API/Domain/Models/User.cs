using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Models
{
    public abstract class User
    {
		public string IdUser { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string CellPhone { get; set; }
		public string IdCard { get; set; }
		public string Description { get; set; }
		public DateTime Birthday { get; set; }
		public string Department { get; set; }
		public string Province { get; set; }
		public string District { get; set; }
		public string Address { get; set; }
		public List<UserPaymentMethod> UserPaymentMethods { get; set; }
		public List<Conversation> Conversations { get; set; }

		//public List<UserConversation> UserConversations { get; set; }
		public string PlanId { set; get; } 
		public Plan Plan { set; get; }
	}
}
