using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twelve_weeks.Models;
using Twelve_weeks.Enums;

namespace Twelve_weeks.Interfaces
{
    internal interface IInfoSaver
    {
        void SaveLongTermPlans(string text);
        void SaveThreeYearPlans(string text);
        string GetLongTermPlans();
        string GetThreeYearPlans();
        void SaveModel(IModel model, FileNamesEnum.FileNames fileName);
        IEnumerable<T> GetModelsList<T>(FileNamesEnum.FileNames fileName) where T: IModel;
        void DeleteModel(string jsonString, FileNamesEnum.FileNames fileName);
    }
}
