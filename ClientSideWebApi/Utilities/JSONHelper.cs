using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ClientSideWebApi.Utilities
{
    public static class JSONHelper
    {
        //Generic Serialize
        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        }
        //Generic Deserialize
        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}