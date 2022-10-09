namespace Twelve_weeks.Pages;
using Twelve_weeks.Components;
using System.Diagnostics;
using Twelve_weeks.Models;
using Twelve_weeks.Enums;

public partial class Days : ContentPage
{

	private FileNamesEnum.FileNames fileName = FileNamesEnum.FileNames.DayTasksFileName;

	public Days()
	{
		InitializeComponent();

		DayTasks.needUpdate += UpdateProgress;

		List<DayModel> models = Singletone.InfoSaver.GetModelsList<DayModel>(
			FileNamesEnum.FileNames.DaysFileName
		).ToList();

		//Debug.WriteLine(models[models.Count - 1].date.ToString());

		if (models.Count == 0 || models[models.Count - 1].date < DateOnly.FromDateTime(DateTime.Now))
		{
			DayModel dayModel = new DayModel() { 
				date = DateOnly.FromDateTime(DateTime.Now),
                progress = Singletone.ProgressUpdater.CountProgress<DayTaskModel>(DateOnly.FromDateTime(DateTime.Now), fileName)
            };

			models.Add(dayModel);
			Singletone.InfoSaver.SaveModel(dayModel, FileNamesEnum.FileNames.DaysFileName);
		}

        models.Reverse();

        foreach (var model in models)
        {
			model.progress = Singletone.ProgressUpdater.CountProgress<DayTaskModel>(model.date, fileName);
            DaysStackLayout.Children.Add(new DayPanel(model));
        }
    }

	public void UpdateProgress()
	{
		foreach(DayPanel day in DaysStackLayout.Children)
		{
			day.DayModel.progress = Singletone.ProgressUpdater.CountProgress<DayTaskModel>(day.DayModel.date, fileName);
		}
	}

}