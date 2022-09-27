namespace Twelve_weeks.Pages;
using Twelve_weeks.Components;
using System.Diagnostics;
using Twelve_weeks.Models;
using Twelve_weeks.Enums;

public partial class Days : ContentPage
{

	public Days()
	{
		InitializeComponent();

		List<DayModel> models = Singletone.InfoSaver.GetModelsList<DayModel>(
			FileNamesEnum.FileNames.DaysFileName
		).ToList();

		//Debug.WriteLine(models[models.Count - 1].date.ToString());

		if (models.Count == 0 || models[models.Count - 1].date < DateOnly.FromDateTime(DateTime.Now))
		{
			DayModel dayModel = new DayModel() { date = DateOnly.FromDateTime(DateTime.Now), progress = 0 };
			models.Add(dayModel);
			Singletone.InfoSaver.SaveModel(dayModel, FileNamesEnum.FileNames.DaysFileName);
		}

        models.Reverse();

        foreach (var model in models)
        {
            DaysStackLayout.Children.Add(new DayPanel(model));
        }
    }
}