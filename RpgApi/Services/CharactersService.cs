using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.WebModels;
using System.Collections.Generic;
using System.Linq;

namespace RpgApi.Services
{
    public class CharactersService
    {
        private static DataContext _dataContext;

        public CharactersService()
        {
            if (_dataContext == null)
            {
                _dataContext = new DataContext();
            }
        }

        public ActionResult<List<Character>> GetAll(bool? isAlive)
        {
            if (isAlive == null)
            {
                return _dataContext.Characters.ToList();
            }

            return _dataContext.Characters
                .Where(x => x.IsAlive == isAlive)
                .ToList();
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

        public ActionResult<Character> AddCharacter(CharacterWebModel characterWebModel)
        {
            int id = _dataContext.Characters
                .Select(x => x.Id)
                .Max();

            Character character = new Character
            {
                Id = id + 1,
                Name = characterWebModel.Name,
                Dmg = characterWebModel.Dmg,
                Hp = characterWebModel.Hp
            };

            _dataContext.Characters.Add(character);

            return new OkObjectResult(character);
        }

        public ActionResult<Character> DealDamageToCharacter(int id, HpToTakeFromCharacterWebModel webModel)
        {
            Character character = _dataContext.Characters
                .SingleOrDefault(x => x.Id == id);

            if (character == null)
            {
                return new NotFoundResult();
            }

            character.Hp -= webModel.Hp;

            return new OkObjectResult(character);
        }

        public ActionResult<Character> DeleteCharacter(int id)
        {
            Character character = _dataContext.Characters
                .SingleOrDefault(x => x.Id == id);

            if (character == null)
            {
                return new NotFoundObjectResult("Didn't find the character");
            }

            _dataContext.Characters.Remove(character);

            return new OkResult();
        }
    }
}
