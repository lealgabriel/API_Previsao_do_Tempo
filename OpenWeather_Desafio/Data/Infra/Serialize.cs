namespace Climate
{
    using Newtonsoft.Json;

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Climate.Converter.Settings);
    }
}


