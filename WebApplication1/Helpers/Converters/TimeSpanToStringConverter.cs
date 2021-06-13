using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dotMovies.Helpers.Converters {
    public class TimeSpanToStringConverter : JsonConverter<TimeSpan> {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var value = reader.GetString();
            try {
                return TimeSpan.Parse(value);
            } catch (Exception e) {
                Console.WriteLine("{0} Exception caught.", e);
            }
            return TimeSpan.Parse("00:00:00");
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options) {
            writer.WriteStringValue(value.ToString());
        }
    }
}
