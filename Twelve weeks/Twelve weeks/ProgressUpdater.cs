using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Twelve_weeks.Enums;
using Twelve_weeks.Models;
using Twelve_weeks.Interfaces;


namespace Twelve_weeks
{
    internal class ProgressUpdater
    {
        public int CountProgress<T>(DateOnly date, FileNamesEnum.FileNames fileName) where T: IModel
        {
            List<T> models = Singletone.InfoSaver.GetModelsList<T>(
                fileName
            ).ToList();

            float completedTasksCount = 0, totalTasksCount = 0;

            foreach (T model in models)
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
