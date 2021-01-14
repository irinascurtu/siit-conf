﻿using AutoMapper;
using Conference.Domain;
using SIIT_Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.Infrastructure
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Speaker, SpeakerDto>();
            CreateMap<SpeakerDto, Speaker>();
            CreateMap<TalkDto, Talk>();
            CreateMap<Talk, TalkDto>();
        }
    }
}
