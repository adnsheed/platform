using System.Text.Json.Serialization;

namespace Platform.Core.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StudentStatus
    {
        InProgram, Success, Failed, Extended
    }
}
