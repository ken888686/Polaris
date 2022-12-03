using Microsoft.AspNetCore.Mvc;
using Polaris.Dtos.Character;
using Polaris.Models;
using Polaris.Services.CharacterService;

namespace Polaris.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class CharacterController : ControllerBase
        {
                private readonly ICharacterService _characterService;

                public CharacterController(ICharacterService characterService)
                {
                        this._characterService = characterService;
                }

                [HttpGet("{id}")]
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

                [HttpPost()]
                public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacterAsync(AddCharacterDto character)
                {
                        var result = await this._characterService.AddCharacterAsync(character);
                        return this.Ok(result);
                }
        }
}
