using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace h0verlord.Integration.Core
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CheckCode : Attribute
    {
        //private  HttpStatusCode code;

        //public CheckCode(HttpStatusCode code)
        //{
        //    this.code = code;
        //}

        //public virtual HttpStatusCode Code
        //{
        //    get { return code; }
        //}

        //public static HttpStatusCode GetAttribute(Type t)
        //{
        //    var attribute = (CheckCode)Attribute.GetCustomAttribute(t, typeof(CheckCode));
        //    return attribute.Code;
        //}
    }
}
