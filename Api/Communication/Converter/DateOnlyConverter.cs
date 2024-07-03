using Newtonsoft.Json;
using System.Globalization;

namespace Api.Communication.Converter
{
    public class DateOnlyConverter : JsonConverter<DateOnly?>
    {
        private const string DateFormat = "yyyy-MM-dd";

        public override void WriteJson(JsonWriter writer, DateOnly? value, JsonSerializer serializer)
        {
            var formattedDate = value?.ToString(DateFormat, CultureInfo.InvariantCulture);
            writer.WriteValue(formattedDate);
        }

        public override DateOnly? ReadJson(
            JsonReader reader,
            Type objectType,
            DateOnly? existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var dateString = reader.Value?.ToString();
            return dateString is null ? null : DateOnly.ParseExact(dateString, DateFormat, CultureInfo.InvariantCulture);
        }
    }
}
