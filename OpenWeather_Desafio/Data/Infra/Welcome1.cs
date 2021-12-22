namespace Climate
{
    using Newtonsoft.Json;

    public partial class Welcome
    {


        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Climate.Converter.Settings);



    }
}


