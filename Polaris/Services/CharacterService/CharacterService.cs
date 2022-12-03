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

                public async Task<List<Character>> GetAllCharactersAsync()
                {
                        return characters;
                }

                public async Task<Character> GetCharacterByIdAsync(int id)
                {
                        var result = characters.FirstOrDefault(x => x.Id.Equals(id));
                        return result ?? new Character();
                }

                public async Task<List<Character>> AddCharacterAsync(Character newCharacter)
                {
                        characters.Add(newCharacter);
                        return characters;
                }
        }
}
