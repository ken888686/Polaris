using System;
using Polaris.Dtos.Character;

namespace Polaris.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<GetCharacterDto>> GetCharacterByIdAsync(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharactersAsync();
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacterAsync(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int id, UpdateCharacterDto updatedCharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}
