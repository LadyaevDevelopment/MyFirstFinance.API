using Newtonsoft.Json;
using System.Globalization;

namespace Api.Communication.Converter
{
    public class DateTimeConverter : JsonConverter<DateTime?>
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

        public override void WriteJson(JsonWriter writer, DateTime? value, JsonSerializer serializer)
        {
            var formattedDate = value?.ToUniversalTime().ToString(DateTimeFormat, CultureInfo.InvariantCulture);
            writer.WriteValue(formattedDate);
        }

        public override DateTime? ReadJson(
            JsonReader reader,
            Type objectType,
            DateTime? existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var dateString = reader.Value?.ToString();
            return dateString is null
                ? null
                : DateTime.ParseExact(
                    dateString,
                    DateTimeFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        }
    }
}
