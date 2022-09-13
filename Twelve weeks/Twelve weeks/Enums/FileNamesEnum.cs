using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twelve_weeks.Enums
{
    internal class FileNamesEnum 
    {
        private readonly string longTermPlanFileName = "LongTermPlan.txt";
        private readonly string threeYearPlanFileName = "ThreeYearPlan.txt";
        private readonly string routineTasksFileName = "RoutineTasks.txt";
        private readonly string lastEnterFileName = "LastEnter.txt";
        private readonly string dayTasksFileName = "DayTasks.txt";
        private readonly string daysFileName = "Days.txt";

        public enum FileNames
        {
            LongTermPlanFileName,
            ThreeYearPlanFileName,
            RoutineTasksFileName, 
            DaysFileName,
            DayTasksFileName,
            LastEnterFileName
        }

        private Dictionary<FileNames, string> dictionary;

        public FileNamesEnum()
        {
            dictionary = new Dictionary<FileNames, string>();
            dictionary[FileNames.LongTermPlanFileName] = longTermPlanFileName;
            dictionary[FileNames.ThreeYearPlanFileName] = threeYearPlanFileName;
            dictionary[FileNames.RoutineTasksFileName] = routineTasksFileName;
            dictionary[FileNames.DaysFileName] = daysFileName;
            dictionary[FileNames.LastEnterFileName] = lastEnterFileName;
            dictionary[FileNames.DayTasksFileName] = dayTasksFileName;
        }

        public string GetFileNameString(FileNames fileName)
        {
            return dictionary[fileName];
        }

    }
}
