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

                public List<Character> AddCharacter(Character newCharacter)
                {
                        characters.Add(newCharacter);
                        return characters;
                }

                public List<Character> GetAllCharacters()
                {
                        return characters;
                }

                public Character GetCharacterById(int id)
                {
                        var result = characters.FirstOrDefault(x => x.Id.Equals(id));
                        return result ?? new Character();
                }
        }
}
