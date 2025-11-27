using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KamaCake.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum  CakeColor
    {
        None =0,
        Red=1,
        Green=2,
        Blue=3,
        Purple=4,
        Black=5,
        White=6,
        Yellow=7,
        Orange=8,
        DeepRed = 9,
        DeepBlue=10


    }
}
