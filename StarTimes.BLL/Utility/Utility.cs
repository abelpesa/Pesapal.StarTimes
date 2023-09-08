using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.BLL.Utility
{
    public class MappingProfile<TSource, TDestination> : Profile
    {
        public MappingProfile()
        {
            CreateMap<TSource, TDestination>();
            RecognizePrefixes("m_");
        }
    }
    public class Utility<TSourceEntity, TDestination> where TSourceEntity : class
    {
        public static TDestination MapEntity(TSourceEntity source)
        {
            var profile = new MappingProfile<TSourceEntity, TDestination>();

            var expr = new MapperConfiguration(config =>
            {
                config.CreateMap<TSourceEntity, TDestination>();
                config.AddProfile(profile);
            });

            var mapper = expr.CreateMapper();
            TDestination result = mapper.Map<TSourceEntity, TDestination>(source);

            return result;
        }

    }



}
