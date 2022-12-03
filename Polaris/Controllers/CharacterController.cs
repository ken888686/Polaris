using Microsoft.AspNetCore.Mvc;

namespace Polaris.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class CharacterController : ControllerBase
        {
                private static List<Character> characters = new List<Character>()
                {
                    new Character(),
                    new Character { Name = "James" }
                };

                public CharacterController()
                {
                }

                [HttpPost()]
                public ActionResult<List<Character>> AddCharacter(Character character)
                {
                        characters.Add(character);
                        return this.Ok(characters);
                }

                [HttpGet("{id}")]
                public ActionResult<Character> Get([FromRoute] int? id)
                {
                        Console.WriteLine(id);
                        return this.Ok(characters.First());
                }

                [HttpGet("all")]
                public ActionResult<List<Character>> GetAll()
                {
                        return this.Ok(characters);
                }
        }
}
