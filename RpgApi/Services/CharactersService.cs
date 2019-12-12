using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RpgApi.Services
{
    public class CharactersService
    {
        private DataContext _dataContext;

        public CharactersService()
        {
            _dataContext = new DataContext();
        }

        public ActionResult<List<Character>> GetAll()
        {
            return _dataContext.Characters.ToList();
        }

        public ActionResult<Character> GetById(int id)
        {
            Character character = _dataContext.Characters
                .SingleOrDefault(x => x.Id == id);

            if (character == null)
            {
                return new NotFoundObjectResult("Element not found.");
            }

            return new OkObjectResult(character);
        }
    }
}
