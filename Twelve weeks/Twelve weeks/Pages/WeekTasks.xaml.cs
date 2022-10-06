namespace Twelve_weeks.Pages;
using Twelve_weeks.Models;
using Twelve_weeks.Enums;
using Twelve_weeks.Components;
using Android.OS;
using System.Threading.Tasks;

public partial class WeekTasks : ContentPage
{
	public WeekTasks()
	{
		InitializeComponent();
        FillTaskStack();
	}

    public void FillTaskStack()
    {
        List<WeekTaskModel> models = Singletone.InfoSaver.GetModelsList<WeekTaskModel>(
            FileNamesEnum.FileNames.WeekTasksFileName
        ).ToList();
        models.Reverse();
        //System.Diagnostics.Debug.Write($"UPDATE ALL TASKS");
        foreach (var currentModel in models)
        {
            if (currentModel.date.DayNumber / 7 == Singletone.DayDate.DayNumber / 7)
            {
                AddTaskToStack(currentModel);
            }
        }
    }

    private void GoBackButton_Clicked(object sender, EventArgs e)
    {
        AppShell.OpenPage(nameof(Weeks));
    }

    public void SaveTask_Clicked(object sender, EventArgs e)
    {
        string title = TaskTitle.Text;
        string description = TaskDescription.Text;
        WeekTaskModel model = new WeekTaskModel() { title = title, description = description, date = Singletone.DayDate };
        AddTaskToStack(model);
        Singletone.InfoSaver.SaveModel(model, FileNamesEnum.FileNames.WeekTasksFileName);

        ChangeGridsVisability(sender, e);
    }

    public void ChangeGridsVisability(object sender, EventArgs e)
    {
        AddTaskGrid.IsVisible = !AddTaskGrid.IsVisible;
        DefaultGrid.IsVisible = !DefaultGrid.IsVisible;
        ClearEditors();
    }

    public void AddTaskToStack(WeekTaskModel model)
    {
        WeekTask task = new WeekTask(model);
        task.deleteThisTask += DeleteTask;
        task.changeCompletion += ChangeCompletion;
        TasksStackLayout.Children.Add(task);
    }

    private async void DeleteTask(WeekTask task)
    {
        bool result = await DisplayAlert("Confirm action", "Do you want delet this task?", "YES", "NO");
        if (result)
        {
            TasksStackLayout.Children.Remove(task);
            Singletone.InfoSaver.DeleteModel(task.Model.GetJsonString(), FileNamesEnum.FileNames.WeekTasksFileName);
        }
    }

    private void ChangeCompletion(WeekTask task)
    {
        System.Diagnostics.Debug.Write($"UPDATE TASK: {task.Model.isDone}");
        Singletone.InfoSaver.ChangeTaskCompletion<WeekTaskModel>(task.Model, FileNamesEnum.FileNames.WeekTasksFileName);
    }

    public void ClearEditors()
    {
        TaskTitle.Text = "";
        TaskDescription.Text = "";
    }
}