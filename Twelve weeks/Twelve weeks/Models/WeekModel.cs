using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Threading.Tasks;
using Twelve_weeks.Interfaces;

namespace Twelve_weeks.Models
{
    public class WeekModel : IModel
    {
        public int id { get; set; }

        [JsonConverter(typeof(DateonlyJsonConverter))]
        public DateOnly date { get; set; }
        public int progress { get; set; }
        public bool isDone { get; set; }

        public string GetJsonString()
        {
            string result = JsonSerializer.Serialize(this);
#if DEBUG
            Debug.WriteLine($"Json saver: {result}");
#endif
            return result;
        }
    }
}
