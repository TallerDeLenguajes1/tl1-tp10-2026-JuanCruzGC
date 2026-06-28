using System.Text.Json.Serialization;

namespace Show;

public class show
{
    [JsonPropertyName("Title")]
    public string titulo{get; set;}
    [JsonPropertyName("Year")]
    public string anio{get; set;}
    [JsonPropertyName("Released")]
    public string lanzamiento{get; set;}
    [JsonPropertyName("Genre")]
    public string genero{get; set;}
    [JsonPropertyName("Type")]
    public string tipo{get; set;}
}
