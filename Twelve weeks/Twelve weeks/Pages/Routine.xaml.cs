namespace Twelve_weeks.Pages;
using Twelve_weeks.Models;
using Twelve_weeks.Components;
using Twelve_weeks.Interfaces;
using System.Diagnostics;
using Twelve_weeks.Enums;
using Twelve_weeks.Pages.Interfaces;

public partial class Routine : ContentPage, ITaskPanel<RoutineTaskModel, RoutineTask>
{
	public Routine()
	{
		InitializeComponent();

        FillTaskStack();
    }

	public void FillTaskStack()
	{
		List<RoutineTaskModel> models = Singletone.InfoSaver.GetModelsList<RoutineTaskModel>(
			FileNamesEnum.FileNames.RoutineTasksFileName
		).ToList();

		foreach (var currentModel in models)
		{
			AddTaskToStack(currentModel);
        }
	}

	public void AddTaskToStack(RoutineTaskModel model)
	{
        RoutineTask task = new RoutineTask(model);
        task.deleteThisTask += DeleteTask;
		TasksStackLayout.Children.Add(task); ;
	}

	private void AddTask_Clicked(object sender, EventArgs e)
	{
		ChangeGridsVisability(sender, e);
    }

    public void SaveTask_Clicked(object sender, EventArgs e)
    {
		string title = TaskTitle.Text;
		string description = TaskDescription.Text;
		RoutineTaskModel model = new RoutineTaskModel() { title = title, description = description };
		AddTaskToStack(model);
		Singletone.InfoSaver.SaveModel(model, FileNamesEnum.FileNames.RoutineTasksFileName);
        ChangeGridsVisability(sender, e);
		ClearEditors();
    }

    private void Exit_Clicked(object sender, EventArgs e)
    {
        ChangeGridsVisability(sender, e);
		ClearEditors();
    }

    public void ChangeGridsVisability(object sender, EventArgs e)
	{
		DefaultGrid.IsVisible = !DefaultGrid.IsVisible;
		AddTaskGrid.IsVisible = !AddTaskGrid.IsVisible;
    }

	public async void DeleteTask(RoutineTask task)
	{
		bool result = await DisplayAlert("Confirm action", "Do you want delet this task?", "YES", "NO");
        if (result)
		{
            TasksStackLayout.Children.Remove(task);
            Singletone.InfoSaver.DeleteModel(task.Model.GetJsonString(), FileNamesEnum.FileNames.RoutineTasksFileName);
        }
	}

	public void ClearEditors()
	{
		TaskTitle.Text = "";
		TaskDescription.Text = "";
	}
}