using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapping configuration between two types source and target
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();//Fix since Id shouldn't be changed because is a key property
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();


            //Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore()); //Fix since Id shouldn't be changed because is a key property
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore()); ;
        }
    }
}