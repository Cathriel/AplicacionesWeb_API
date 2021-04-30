using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Models
{
    public class Leaseholder : User
    {
        public List<Review> Reviews { set; get; }
        public List<FavouritePost> FavouritePosts { set; get; }
    }
}
