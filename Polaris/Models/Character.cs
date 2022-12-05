namespace Polaris.Models
{
    public class Character
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "Unknown";
        public int HitPoint { get; set; } = 0;
        public int Strength { get; set; } = 0;
        public int Defense { get; set; } = 0;
        public int Intelligence { get; set; } = 0;
        public RpgClass Class { get; set; } = RpgClass.Knight;
        public User? User { get; set; }
    }
}
