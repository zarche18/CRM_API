using AutoMapper;
using GoFive_CRM.Application.Models;
using GoFive_CRM.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFive_CRM.Application.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<GoFive_CRMDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
    public class GoFive_CRMDtoMapper : Profile
    {
        public GoFive_CRMDtoMapper()
        {
            CreateMap<Customers, CustomerModel>().ReverseMap();
        }

    }
}
