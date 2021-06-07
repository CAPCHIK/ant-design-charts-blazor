using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AntDesign.Charts.Components.Configs
{
    public class Options
    {
        /// <summary>
        /// Canvas width
        /// </summary>
        [JsonPropertyName("width")]
        public float? Width { get; set; }
        /// <summary>
        /// Canvas height
        /// </summary>
        [JsonPropertyName("heigth")]
        public float? Heigth { get; set; }
        [JsonPropertyName("autoFit")]
        public bool? AutoFit { get; set; }
        [JsonPropertyName("padding")]
        [JsonConverter(typeof(OneOfConverter))]
        public OneOf<float, float[], AutoValue>? Padding { get; set; }
    }
}
