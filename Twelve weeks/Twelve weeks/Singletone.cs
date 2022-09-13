using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twelve_weeks.Saving;
using Twelve_weeks.Interfaces;
using System.Diagnostics;

namespace Twelve_weeks
{
    internal class Singletone
    {
        private static Singletone instance;
        private IInfoSaver infoSaver;
        private IDatesSaver dateSaver;
        private DateOnly dayDate;

        public Singletone(IInfoSaver saver, IDatesSaver dateSaver)
        {
            Debug.Write("dd");
            instance = this;
            this.infoSaver = saver;
            this.dateSaver = dateSaver;
        }

        public static IInfoSaver InfoSaver
        {
            get
            {
                return instance.infoSaver;
            }
        }

        public static IDatesSaver DateSaver
        {
            get
            {
                return instance.dateSaver;
            }
        }
        
        public static DateOnly DayDate
        {
            get
            {
                return instance.dayDate;
            }
            set
            {
                instance.dayDate = value;
            }
        }
    }
}
