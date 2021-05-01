using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Models
{
    public class Review
    {
        public string Id { set; get; }
        public string Content { set; get; }
        public DateTime Date { set; get; }
        public int StarQuantity { set; get; }
        public Leaseholder Leaseholder { set; get; }
        public string LeaseholderId { set; get; }
        public Landlord Landlord { set; get; }
        public string LandlordId { set; get; }
        public Post Post { set; get; }
        public string PostId { set; get; }

    }
}
