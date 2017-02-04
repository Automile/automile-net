using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Automile.Net
{
    public static class Extensions
    {
        public static void EnsureSuccessStatusCodeWithProperExceptionMessage(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var code = response.StatusCode;
                var phrase = response.ReasonPhrase;
                string msg = response.Content.ReadAsStringAsync().Result;
                throw new Exception($"Code: {code} Phrase: {phrase} Message: {msg}");
            }
        }
    }
}
