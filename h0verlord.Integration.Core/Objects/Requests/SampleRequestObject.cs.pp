using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $rootnamespace$.Objects
{
    class SampleRequestObject
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }
    }
}
