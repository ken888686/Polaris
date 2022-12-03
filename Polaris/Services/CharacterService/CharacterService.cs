using System;

namespace Polaris.Services.CharacterService
{
        public class CharacterService : ICharacterService
        {
                private static List<Character> characters = new List<Character>
                {
                        new Character(),
                        new Character
                        {
                                Id = 1,
                                Name = "Aaron"
                        }
                };

                public CharacterService()
                {
                }

                public async Task<ServiceResponse<List<Character>>> GetAllCharactersAsync()
                {
                        var serviceResponse = new ServiceResponse<List<Character>>();
                        serviceResponse.Data = characters;
                        return serviceResponse;
                }

                public async Task<ServiceResponse<Character>> GetCharacterByIdAsync(int id)
                {
                        var serviceResponse = new ServiceResponse<Character>();
                        var result = characters.FirstOrDefault(x => x.Id.Equals(id));
                        serviceResponse.Data = result;
                        return serviceResponse;
                }

                public async Task<ServiceResponse<List<Character>>> AddCharacterAsync(Character newCharacter)
                {
                        var serviceResponse = new ServiceResponse<List<Character>>();
                        characters.Add(newCharacter);
                        serviceResponse.Data = characters;
                        return serviceResponse;
                }
        }
}
