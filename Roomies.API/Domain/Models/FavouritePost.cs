using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Models
{
    public class FavouritePost
    {
        public string PostId { set; get; }
        public Post Post { set; get; }
        public string LeaseholderId { set; get; }
        public Leaseholder Leaseholder { set; get; }

    }
}
