using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Twelve_weeks.Enums;
using Twelve_weeks.Models;

namespace Twelve_weeks
{
    internal class ProgressUpdater
    {
        public int CountProgress(DateOnly date)
        {
            List<DayTaskModel> models = Singletone.InfoSaver.GetModelsList<DayTaskModel>(
                FileNamesEnum.FileNames.DayTasksFileName
            ).ToList();

            float completedTasksCount = 0, totalTasksCount = 0;

            foreach (var model in models)
            {
                if (model.date == date )
                {
                    totalTasksCount++;
                    if (model.isDone)
                    {
                        completedTasksCount++;
                    }
                }
            }

            if (totalTasksCount == 0)
            {
                return 0;
            }

            System.Diagnostics.Debug.WriteLine($"GETTING PROGRESS {date}, {completedTasksCount} {totalTasksCount}");
            float result = ((float)completedTasksCount / (float)totalTasksCount) * 100;
            return (int)result;
        }
    }
}
