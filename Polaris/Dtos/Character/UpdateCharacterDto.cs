using System;
namespace Polaris.Dtos.Character
{
        public class UpdateCharacterDto
        {
                public string? Name { get; set; }
                public int HitPoint { get; set; }
                public int Strenth { get; set; }
                public int Defense { get; set; }
                public int Intelligence { get; set; }
                public RpgClass Class { get; set; }
        }
}
