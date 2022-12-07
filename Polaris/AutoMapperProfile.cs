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
            CreateMap<UpdateCharacterDto, Character>()
                .ForMember(dest => dest.Name, opt => opt.Condition(src => !string.IsNullOrWhiteSpace(src.Name)))
                .ForMember(dest => dest.HitPoint, opt => opt.Condition(src => src.HitPoint != 0))
                .ForMember(dest => dest.Strength, opt => opt.Condition(src => src.Strength != 0))
                .ForMember(dest => dest.Defense, opt => opt.Condition(src => src.Defense != 0))
                .ForMember(dest => dest.Intelligence, opt => opt.Condition(src => src.Intelligence != 0))
                .ForMember(dest => dest.Class, opt => opt.Condition(src => src.Class != RpgClass.Unknown));
        }
    }
}
