using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Twelve_weeks.Interfaces;
using System.Diagnostics;

namespace Twelve_weeks.Models
{
    public class RoutineTaskModel : IModel
    {
        public int id { get; set; }
        public bool isDone { get; set; }

        public string title { get; set; }
        public string description { get; set; }

        public string GetJsonString()
        {
            string output = JsonSerializer.Serialize(this);
#if DEBUG
            Debug.WriteLine($"Convert: {output}");
#endif
            return output;
        }
    }
}
