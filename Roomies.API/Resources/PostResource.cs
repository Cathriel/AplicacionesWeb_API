﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Resources
{
    public class PostResource
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
    }
}