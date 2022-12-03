namespace Polaris.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Aaron";
        public int HitPoint { get; set; } = 100;
        public int Strenth { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}
