using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Services;
using System.Collections.Generic;

namespace RpgApi.Controllers
{
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private const string Route = "api/characters/";

        private CharactersService _charactersService;

        public CharactersController()
        {
            _charactersService = new CharactersService();
        }

        [HttpGet(Route)]
        public ActionResult<List<Character>> Get()
        {
            return _charactersService.GetAll();
        }

        [HttpGet(Route + "{id}")]
        public ActionResult<Character> GetById(int id)
        {
            return _charactersService.GetById(id);
        }
    }
}
