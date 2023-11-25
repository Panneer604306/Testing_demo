using AutoMapper;
using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LenovoDWI.AutoMapper
{
    public class AuthMapping : Profile
    {
        public AuthMapping()
        {
            this.CreateMap<Login, UserLogin>();
        }
    }
}
