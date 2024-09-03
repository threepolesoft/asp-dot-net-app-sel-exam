using System.Text.Json.Serialization;

namespace WebApiApp.Model
{
    public class Res
    {
        [JsonPropertyName("Status")]
        public bool status { get; set; }

        [JsonPropertyName("Message")]
        public string message { get;set; }

        [JsonPropertyName("Data")]
        public object data { get; set; }
    }
}
