using AutoMapper;
using EcomShop.WebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcomShop.Application.Customers.DTO
{
    public class CustomerAutoMapperProfile : Profile
    {
        public CustomerAutoMapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
