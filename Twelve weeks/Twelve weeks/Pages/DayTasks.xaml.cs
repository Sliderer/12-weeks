namespace Twelve_weeks.Components;
using Twelve_weeks.Enums;
using Twelve_weeks.Models;
using Twelve_weeks.Pages;
using Twelve_weeks.Pages.Interfaces;

public partial class DayTasks : ContentPage, ITaskPanel<DayTaskModel, DayTask>
{
    public  delegate void NeedUpdate();
    public static event NeedUpdate needUpdate;

    private FileNamesEnum.FileNames fileNames = FileNamesEnum.FileNames.DayTasksFileName;

    public DayTasks()
	{
		InitializeComponent();
        FillTaskStack();
    }

    public void FillTaskStack()
    {
        List<DayTaskModel> models = Singletone.InfoSaver.GetModelsList<DayTaskModel>(
            fileNames
        ).ToList();
        models.Reverse();

        foreach (var currentModel in models)
        {
            if (currentModel.date == Singletone.DayDate)
            {
                AddTaskToStack(currentModel);
            }
        }
    }

	private void GoBackButton_Clicked(object sender, EventArgs e)
	{
		AppShell.OpenPage(nameof(Days));
	}

	public void SaveTask_Clicked(object sender, EventArgs e)
	{
        string title = TaskTitle.Text;
        string description = TaskDescription.Text;
        DayTaskModel model = new DayTaskModel() { title = title, description = description, date = Singletone.DayDate };
        AddTaskToStack(model);
        Singletone.InfoSaver.SaveModel(model, fileNames);

        ChangeGridsVisability (sender, e);
    }

    public void ChangeGridsVisability(object sender, EventArgs e)
    {
        AddTaskGrid.IsVisible = !AddTaskGrid.IsVisible;
        DefaultGrid.IsVisible = !DefaultGrid.IsVisible;
		ClearEditors();
    }

    public void AddTaskToStack(DayTaskModel model) 
    {
        DayTask task = new DayTask(model);
        task.deleteThisTask += DeleteTask;
        task.changeCompletion += ChangeCompletion;
        TasksStackLayout.Children.Add(task); ;
    }

    public async void DeleteTask(DayTask task)
    {
        bool result = await DisplayAlert("Confirm action", "Do you want delet this task?", "YES", "NO");
        if (result)
        {
            TasksStackLayout.Children.Remove(task);
            Singletone.InfoSaver.DeleteModel(task.Model.GetJsonString(), fileNames);
        }
    }

    private void ChangeCompletion(DayTask task)
    {
        needUpdate.Invoke();
        Singletone.InfoSaver.ChangeTaskCompletion<DayTaskModel>(task.Model, fileNames);
    }

    public void ClearEditors()
    {
        TaskTitle.Text = "";
        TaskDescription.Text = "";
    }
}