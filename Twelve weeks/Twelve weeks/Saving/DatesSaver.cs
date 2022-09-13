using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Twelve_weeks.Interfaces;
using Twelve_weeks.Enums;

namespace Twelve_weeks.Saving
{
    internal class DatesSaver : IDatesSaver
    {
        private FileNamesEnum fileNames;
        public DatesSaver()
        {
            fileNames = new FileNamesEnum();
            FilesController.CheckFile(fileNames.GetFileNameString(FileNamesEnum.FileNames.LastEnterFileName));
        }

        public DateTime GetLastEnterDate()
        {
            string dateString = FilesController.ReadFile(fileNames.GetFileNameString(FileNamesEnum.FileNames.LastEnterFileName));
            DateTime date = DateTime.Parse(dateString);
            return date;
        }

        public void UpdateEnterDate()
        {
            string date = DateTime.Now.ToString();
            Debug.WriteLine($"date : {date}");
            FilesController.WriteFile(fileNames.GetFileNameString(FileNamesEnum.FileNames.LastEnterFileName), date);
        }
    }
}
