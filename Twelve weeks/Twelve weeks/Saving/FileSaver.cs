using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Twelve_weeks.Interfaces;
using Twelve_weeks.Models;
using System.Diagnostics;
using Twelve_weeks.Enums;
using static Twelve_weeks.Enums.FileNamesEnum;


namespace Twelve_weeks.Saving
{
    internal class FileSaver : IInfoSaver
    {
        private FileNamesEnum fileNamesEnums;
        
        public FileSaver()
        {
            fileNamesEnums = new FileNamesEnum();
            FilesController.CheckFile(fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.LongTermPlanFileName));
            FilesController.CheckFile(fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.ThreeYearPlanFileName));
            FilesController.CheckFile(fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.RoutineTasksFileName));
            FilesController.CheckFile(fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.DayTasksFileName));
            FilesController.CheckFile(fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.DaysFileName));
            FilesController.CheckFile(fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.WeeksFileName));
            FilesController.CheckFile(fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.WeekTasksFileName));
            //FilesController.DeleteFile(fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.RoutineTasksFileName));
            //FilesController.DeleteFile(fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.WeekTasksFileName));
            //Debug.WriteLine("FILE:" + FilesController.ReadFile(fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.LastEnterFileName)));
        }

        public string GetLongTermPlans()
        {
            return FilesController.ReadFile(fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.LongTermPlanFileName));
        }

        public string GetThreeYearPlans()
        {
            return FilesController.ReadFile(fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.ThreeYearPlanFileName));
        }

        public void SaveLongTermPlans(string text)
        {
            FilesController.WriteFile(text, fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.LongTermPlanFileName));
        }

        public void SaveThreeYearPlans(string text)
        {
            FilesController.WriteFile(text, fileNamesEnums.GetFileNameString(FileNamesEnum.FileNames.ThreeYearPlanFileName));
        }

        public void SaveModel(IModel model, FileNamesEnum.FileNames fileName )
        {
            string text = model.GetJsonString() + "\n";
            FilesController.AppendFile(text, fileNamesEnums.GetFileNameString(fileName));
        }

        public IEnumerable<T> GetModelsList<T>(FileNamesEnum.FileNames fileName) where T : IModel
        {
            string[] jsonModels = FilesController.ReadFileLines(fileNamesEnums.GetFileNameString(fileName));
            foreach(var i in jsonModels){
#if DEBUG
                Debug.WriteLine($"save: {i}");
#endif
                T model;
                try
                {
                    model = (T)JsonSerializer.Deserialize(i, typeof(T));
                }
                catch
                {
                    continue;
                }
                yield return model;

            }
        }

        public void DeleteModel(string jsonString, FileNames fileName)
        {
            string text = FilesController.ReadFile(fileNamesEnums.GetFileNameString(fileName));
            text = text.Replace(jsonString, "");
            Debug.WriteLine($"change: {text}");
            FilesController.WriteFile(text, fileNamesEnums.GetFileNameString(fileName));
        }

        public void ChangeTaskCompletion<T>(T model, FileNames fileName) where T : IModel
        {
            string text = FilesController.ReadFile(fileNamesEnums.GetFileNameString(fileName));

            string oldJsonString = model.GetJsonString();
            model.isDone = !model.isDone;
            string newJsonString = model.GetJsonString();

            Debug.WriteLine($"EQUALS {text.Contains(oldJsonString)}");
            text = text.Replace(oldJsonString, newJsonString);
            Debug.WriteLine($"TEXT: {text} \n OLDSTRING: {oldJsonString}\n NEWSTRING: {newJsonString}");

            FilesController.WriteFile(text, fileNamesEnums.GetFileNameString(fileName));
        }
    }
}
