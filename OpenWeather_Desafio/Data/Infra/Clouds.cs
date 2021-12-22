namespace Climate
{
    using Newtonsoft.Json;

    public partial class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}


