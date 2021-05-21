using AutoMapper;
using Roomies.API.Domain.Models;
using Roomies.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveMessageResource, Message>();
            CreateMap<SavePaymentMethod, PaymentMethod>();
            CreateMap<SavePostResource, Post>();
            CreateMap<SaveReviewResource, Review>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveLandlordResource, Landlord>();
            CreateMap<SaveLeaseholderResource, Leaseholder>();
            
            
        }
    }
}
