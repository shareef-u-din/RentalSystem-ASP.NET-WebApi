using AutoMapper;
using RentalSystem.DAL;
using RentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.BL.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();
        }
    }
}
