using Microsoft.AspNetCore.Mvc;
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

                [HttpPost()]
                public ActionResult<List<Character>> AddCharacter(Character character)
                {
                        var result = this._characterService.AddCharacter(character);
                        return this.Ok(result);
                }

                [HttpGet("{id}")]
                public ActionResult<Character> Get([FromRoute] int id)
                {
                        var character = this._characterService.GetCharacterById(id);
                        return this.Ok(character);
                }

                [HttpGet("all")]
                public ActionResult<List<Character>> GetAll()
                {
                        var characters = this._characterService.GetAllCharacters();
                        return this.Ok(characters);
                }
        }
}
