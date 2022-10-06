using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Twelve_weeks.Interfaces;
using Twelve_weeks.Enums;
using System.Text.Json.Serialization;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;


namespace Twelve_weeks.Models
{
    public class DayModel : IModel
    {
        public int id { get; set; }

        public bool isDone { get; set; }

        [JsonConverter(typeof(DateonlyJsonConverter))]
        public DateOnly date { get; set; }
        public int progress { get; set; }

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
