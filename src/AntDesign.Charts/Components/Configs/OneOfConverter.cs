using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AntDesign.Charts.Components.Configs
{
    public class OneOfConverter : JsonConverter<IOneOf>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType)
                return false;

            var underlyingType = Nullable.GetUnderlyingType(typeToConvert);
            if (underlyingType != null)
            {
                return typeof(IOneOf).IsAssignableFrom(underlyingType);
            }
            return typeof(IOneOf).IsAssignableFrom(typeToConvert);
        }
        public override IOneOf Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => throw new NotImplementedException($"Reading IOneOf not implemented, because should be used only for passing options");

        public override void Write(Utf8JsonWriter writer, IOneOf value, JsonSerializerOptions options)
            => JsonSerializer.Serialize(writer, value.Value, value.Value.GetType(), options);
    }
}
