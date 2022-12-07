using System.Text.Json.Serialization;

namespace Polaris.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Unknown = 0,
        Knight,
        Mage,
        Cleric
    }
}
