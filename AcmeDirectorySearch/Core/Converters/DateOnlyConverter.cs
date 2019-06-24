namespace AcmeDirectorySearch.Core.Converters
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;

    /// <summary>
    /// Custom Converter for JSON.Net which limits the 
    /// output of a DateTime object to being only a short date
    /// </summary>
    public class DateOnlyConverter : JsonConverter
    {
        private readonly string dateFormat = "MM/dd/yyyy";

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTime.ParseExact((string)reader.Value, this.dateFormat, CultureInfo.InvariantCulture);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

            DateTime date = (DateTime)value;
            writer.WriteValue(date.ToString(this.dateFormat));
        }
    }
}
