using System;
using AutoMapper;
using Polaris.Dtos.Character;

namespace Polaris
{
        public class AutoMapperProfile : Profile
        {
                public AutoMapperProfile()
                {
                        CreateMap<Character, GetCharacterDto>();
                        CreateMap<AddCharacterDto, Character>();
                }
        }
}

