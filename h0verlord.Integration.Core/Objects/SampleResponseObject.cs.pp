using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $rootnamespace$.Objects
{
    class SampleResponseObject
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

    }
}
