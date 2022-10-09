using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twelve_weeks.Interfaces
{
    public interface IModel
    {
        int id { get; set; }
        bool isDone { get; set; }
        DateOnly date { get; set; }
        string GetJsonString();
    }
}
