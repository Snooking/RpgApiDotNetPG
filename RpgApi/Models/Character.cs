namespace RpgApi.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Dmg { get; set; }
        public int Hp { get; set; }
        public bool IsAlive { get => Hp > 0; }
    }
}
