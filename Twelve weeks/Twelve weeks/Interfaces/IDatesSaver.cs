using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twelve_weeks.Interfaces
{
    internal interface IDatesSaver
    {
        DateTime GetLastEnterDate();

        void UpdateEnterDate();
    }
}
