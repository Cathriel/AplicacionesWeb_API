﻿using AutoMapper;
using Roomies.API.Domain.Models;
using Roomies.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Conversation, ConversationResource>();

            CreateMap<Message, MessageResource>();

            CreateMap<PaymentMethod, PaymentMethodResource>();
            CreateMap<Plan, PlanResource>();
            CreateMap<Review, ReviewResource>();
            CreateMap<Post, PostResource>();
            CreateMap<User, UserResource>();

            /* CreateMap<Category, CategoryResource>();

             CreateMap<Product, ProductResource>()
                 .ForMember(src => src.UnitOfMeasurement,
                 opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));

             CreateMap<Tag, TagResource>();*/

        }
    }
}
