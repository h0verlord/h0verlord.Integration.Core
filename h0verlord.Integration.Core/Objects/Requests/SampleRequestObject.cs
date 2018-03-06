using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h0verlord.Integration.Core.Objects
{
    class SampleRequestObject
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }
    }
}
