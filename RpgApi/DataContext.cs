using RpgApi.Models;
using System.Collections.Generic;

namespace RpgApi
{
    public class DataContext
    {
        public List<Character> Characters { get; set; }

        public DataContext()
        {
            Characters = new List<Character>
            {
                new Character
                {
                    Id = 1,
                    Name = "Snooking",
                    Dmg = 4,
                    Hp = 14
                },
                new Character
                {
                    Id = 2,
                    Name = "Huzdy",
                    Dmg = 5,
                    Hp = 0
                }
            };
        }
    }
}
