using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Automile.Net
{

    public class TripEditModel
    {
        public string CustomCategory { get; set; }

        public ApiTripType TripType { get; set; }

        [JsonConverter(typeof(CustomStringConverter))]
        public List<string> TripTags { get; set; }

        public int? LastEditedByContactId { get; set; }
    }

    public class CustomStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, JArray.Parse(value as string));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                                        JsonSerializer serializer)
        {         
            if (reader.Value is string)
            {
                return new List<string>() { reader.Value.ToString() };
            }
            else
            {
                try
                {
                    var array = JArray.Load(reader);
                    var json = JsonConvert.SerializeObject(array);
                    return JsonConvert.DeserializeObject<List<string>>(json);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
