using System;
namespace Polaris.Services.CharacterService
{
        public interface ICharacterService
        {
                Task<ServiceResponse<Character>> GetCharacterByIdAsync(int id);
                Task<ServiceResponse<List<Character>>> GetAllCharactersAsync();
                Task<ServiceResponse<List<Character>>> AddCharacterAsync(Character newCharacter);
        }
}
