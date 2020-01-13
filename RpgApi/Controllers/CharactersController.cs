using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Services;
using RpgApi.WebModels;
using System.Collections.Generic;

namespace RpgApi.Controllers
{
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private const string Route = "api/characters/";

        private ICharactersService _charactersService;

        public CharactersController(ICharactersService charactersService)
        {
            _charactersService = charactersService;
        }

        [HttpGet(Route)]
        public ActionResult<List<Character>> Get([FromQuery] bool? isAlive)
        {
            return _charactersService.GetAll(isAlive);
        }

        [HttpGet(Route + "{id}")]
        public ActionResult<Character> GetById([FromRoute] int id)
        {
            return _charactersService.GetById(id);
        }

        [HttpPost(Route)]
        public ActionResult<Character> AddCharacter([FromBody] CharacterWebModel characterWebModel)
        {
            return _charactersService.AddCharacter(characterWebModel);
        }

        [HttpPut(Route + "{id}")]
        public ActionResult<Character> DealDamageToCharacter([FromRoute] int id, [FromBody] HpToTakeFromCharacterWebModel webModel)
        {
            return _charactersService.DealDamageToCharacter(id, webModel);
        }

        [HttpDelete(Route + "{id}")]
        public ActionResult<Character> DeleteCharacter([FromRoute] int id)
        {
            return _charactersService.DeleteCharacter(id);
        }
    }
}
