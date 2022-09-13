using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twelve_weeks.Interfaces;
using Twelve_weeks.Enums;


namespace Twelve_weeks.Pages.Containers
{
    internal class TaskPageAbstractClass<ModelTemplate, ComponentTemplate>
        where ModelTemplate : IModel
        where ComponentTemplate : ContentView
    {
        //internal void FillScrollView(StackLayout stack)
        //{
        //    List<ModelTemplate> models = Singletone.InfoSaver.GetModelsList<ModelTemplate>(
        //     FileNamesEnum.FileNames.DayTasksFileName
        //    ).ToList();

        //    foreach (var model in models)
        //    {
        //        AddTaskToStack(model, stack);
        //    }
        //}

    }
}
