using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Resources
{
    public class UserResource
    {
		public int IdUser { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public string CellPhone { get; set; }
		public string IdCard { get; set; }
		public string Description { get; set; }
		public DateTime Birthday { get; set; }
		public string Department { get; set; }
		public string Province { get; set; }
		public string District { get; set; }
		public PlanResource Plan{ set; get; }
		public DateTime StartSubscription { set; get; }
		public DateTime EndSubsciption { set; get; }
	}
}
