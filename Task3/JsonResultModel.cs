using System.Text.Json.Serialization;

namespace Task3
{
    public class JsonResultModel
    {
        [JsonPropertyName("successful")]
        public int Successful { get; set; }
        [JsonPropertyName("failed")]
        public int Failed { get; set; }

        public JsonResultModel(int successful, int failed)
        {
            Successful = successful;
            Failed = failed;
        }
    }
}
