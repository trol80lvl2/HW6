using System.Text.Json.Serialization;

namespace Task2
{
    public class Settings
    {
        [JsonPropertyName("primesFrom")]
        public int PrimesFrom { get; set; }
        [JsonPropertyName("primesTo")]
        public int PrimesTo { get; set; }

        public Settings() { }
        public Settings(int from, int to)
        {
            PrimesFrom = from;
            PrimesTo = to;
        }
    }
}
