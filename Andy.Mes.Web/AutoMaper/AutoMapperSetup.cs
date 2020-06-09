using Andy.Mes.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andy.Mes.Web
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap(typeof(LoginDto), typeof(UserInfo)).ReverseMap();

            CreateMap<SysMgrUserViewModel, SysMgrUser>().ForMember(f => f._sex, opt =>opt.Ignore()).ReverseMap();
        }
    }
}
