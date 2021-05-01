using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Resources
{
    public class ReviewResource
    {
        public string Id { set; get; }
        public string Content { set; get; }
        public DateTime Date { set; get; }
        public int StarQuantity { set; get; }
    }
}
