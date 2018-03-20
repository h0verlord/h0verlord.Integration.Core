using RestSharp.Deserializers;

namespace $rootnamespace$.Objects
{
    class SampleRequestObject
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }
    }
}
