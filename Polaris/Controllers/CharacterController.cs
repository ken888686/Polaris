using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polaris.Dtos.Character;
using Polaris.Models;
using Polaris.Services.CharacterService;

namespace Polaris.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetAsync([FromRoute] int id)
        {
            var character = await this._characterService.GetCharacterByIdAsync(id);
            return this.Ok(character);
        }

        [HttpGet("")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAllAsync()
        {
            var characters = await this._characterService.GetAllCharactersAsync();
            return this.Ok(characters);
        }

        [HttpPost("")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacterAsync([FromBody] AddCharacterDto newCharacter)
        {
            var result = await this._characterService.AddCharacterAsync(newCharacter);
            return this.Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacterAsync([FromRoute] int id, [FromBody] UpdateCharacterDto updatedCharacter)
        {
            var result = await this._characterService.UpdateCharacter(id, updatedCharacter);
            return result.Data == null ? this.BadRequest(result) : this.Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteAsync([FromRoute] int id)
        {
            var result = await this._characterService.DeleteCharacter(id);
            return result;
        }
    }
}
