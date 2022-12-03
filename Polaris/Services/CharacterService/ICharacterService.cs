using System;
namespace Polaris.Services.CharacterService
{
        public interface ICharacterService
        {
                Task<Character> GetCharacterByIdAsync(int id);
                Task<List<Character>> GetAllCharactersAsync();
                Task<List<Character>> AddCharacterAsync(Character newCharacter);
        }
}
