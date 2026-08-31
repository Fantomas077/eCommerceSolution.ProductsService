using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Mappers
{
    public class ProductsMappingProfile:Profile
    {
        public ProductsMappingProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<ProductUpdateRequest,Product>();
            CreateMap<ProductAddRequest, Product>();





        }
    }
}
