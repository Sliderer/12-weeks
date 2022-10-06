using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Twelve_weeks.Interfaces;

namespace Twelve_weeks.Models
{
    internal class PlanModel : IModel
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool isDone { get; set; }

        public string GetJsonString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
