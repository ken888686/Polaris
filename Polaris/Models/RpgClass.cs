using System.Text.Json.Serialization;

namespace Polaris.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,
        Mage,
        Cleric
    }
}
