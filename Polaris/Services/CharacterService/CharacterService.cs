using System;
using AutoMapper;
using Polaris.Dtos.Character;
using Polaris.Models;

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

                public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int id, UpdateCharacterDto updatedCharacter)
                {
                        var serviceResponse = new ServiceResponse<GetCharacterDto>();
                        var character = characters.FirstOrDefault(x => x.Id.Equals(id));
                        if (character == null)
                        {
                                serviceResponse.Data = null;
                                serviceResponse.Message = $"Id({id}) does not exitst.";
                                serviceResponse.Success = false;
                                return serviceResponse;
                        }

                        this._mapper.Map(updatedCharacter, character);

                        serviceResponse.Data = this._mapper.Map<GetCharacterDto>(character);
                        return serviceResponse;
                }

                public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
                {
                        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
                        var character = characters.FirstOrDefault(x => x.Id.Equals(id));
                        if (character == null)
                        {
                                serviceResponse.Data = null;
                                serviceResponse.Message = $"Id({id}) does not exitst.";
                                serviceResponse.Success = false;
                                return serviceResponse;
                        }

                        characters.Remove(character);
                        serviceResponse.Data = characters.Select(x => this._mapper.Map<GetCharacterDto>(x)).ToList();
                        return serviceResponse;
                }
        }
}
