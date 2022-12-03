using System;
using AutoMapper;
using Polaris.Dtos.Character;

namespace Polaris.Services.CharacterService
{
        public class CharacterService : ICharacterService
        {
                private static List<Character> characters = new List<Character>
                {
                        new Character
                        {
                                Id = 1,
                                Name = "Jason"
                        },
                        new Character
                        {
                                Id = 2,
                                Name = "Aaron"
                        }
                };

                private readonly IMapper _mapper;

                public CharacterService(IMapper mapper)
                {
                        this._mapper = mapper;
                }

                public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharactersAsync()
                {
                        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
                        serviceResponse.Data = this._mapper.Map<List<GetCharacterDto>>(characters);
                        return serviceResponse;
                }

                public async Task<ServiceResponse<GetCharacterDto>> GetCharacterByIdAsync(int id)
                {
                        var serviceResponse = new ServiceResponse<GetCharacterDto>();
                        var result = characters.FirstOrDefault(x => x.Id.Equals(id));
                        serviceResponse.Data = this._mapper.Map<GetCharacterDto>(result);
                        return serviceResponse;
                }

                public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacterAsync(AddCharacterDto newCharacter)
                {
                        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
                        var dto = this._mapper.Map<Character>(newCharacter);
                        dto.Id = characters.Max(x => x.Id) + 1;
                        characters.Add(dto);
                        serviceResponse.Data = this._mapper.Map<List<GetCharacterDto>>(characters);
                        return serviceResponse;
                }

                public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
                {
                        var serviceResponse = new ServiceResponse<GetCharacterDto>();
                        var character = characters.FirstOrDefault(x => x.Id.Equals(updatedCharacter.Id));

                        character.Name = updatedCharacter.Name;
                        character.HitPoint = updatedCharacter.HitPoint;
                        character.Strenth = updatedCharacter.Strenth;
                        character.Defense = updatedCharacter.Defense;
                        character.Intelligence = updatedCharacter.Intelligence;
                        character.Class = updatedCharacter.Class;

                        serviceResponse.Data = this._mapper.Map<GetCharacterDto>(character);
                        return serviceResponse;
                }
        }
}
