using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Twelve_weeks.Interfaces;
using Twelve_weeks.Enums;
using System.Text.Json.Serialization;

namespace Twelve_weeks.Models
{
    public class DayTaskModel : IModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }

        [JsonConverter(typeof(DateonlyJsonConverter))]
        public DateOnly date { get; set; }

        public TimeTypesEnum.TimeTypes timeType { get; set; }

        public string GetJsonString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
