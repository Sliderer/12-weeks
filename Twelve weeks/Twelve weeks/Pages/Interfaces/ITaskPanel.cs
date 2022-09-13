using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twelve_weeks.Interfaces;

namespace Twelve_weeks.Pages.Interfaces
{
    internal interface ITaskPanel<ModelTemplate, TaskPanel> where ModelTemplate : IModel
    {
        void FillTaskStack();

        void SaveTask_Clicked(object sender, EventArgs e);

        void ChangeGridsVisability(object sender, EventArgs e);

        void AddTaskToStack(ModelTemplate model);

        void DeleteTask(TaskPanel taskPanel);

        void ClearEditors();
    }
}
