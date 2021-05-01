﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Domain.Models
{
    public class Post
    {
        public string Id { set; get; }
        public string Title { set; get; }
        public string Address { set; get; }
        public string Province { set; get; }
        public string District { set; get; }
        public string Department { set; get; }
        public float Price { set; get; }
        public int RoomQuantity { set; get; }
        public int BathroomQuantity { set; get; }
        public DateTime PostDate { set; get; }
        public List<Review> Reviews { set; get; }
        public List<FavouritePost> FavouritePosts { set; get; }
        public Landlord Landlord { set; get; }
        public string LandlordId { set; get; }
    }
}
