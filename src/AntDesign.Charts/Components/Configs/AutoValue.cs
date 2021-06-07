using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AntDesign.Charts.Components.Configs
{
    [JsonConverter(typeof(AutoValueConverter))]
    public class AutoValue
    {
        private static readonly AutoValue instance = new AutoValue();
        private AutoValue() {}
        public static AutoValue Instance => instance;
    }
    public class AutoValueConverter : JsonConverter<AutoValue>
    {
        public override AutoValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => AutoValue.Instance;

        public override void Write(Utf8JsonWriter writer, AutoValue value, JsonSerializerOptions options)
            => writer.WriteStringValue("auto");
    }
}
