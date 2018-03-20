using RestSharp.Deserializers;

namespace $rootNamespace$.Objects
{
    class SampleResponseObject
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

    }
}
