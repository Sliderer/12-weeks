namespace Twelve_weeks.Pages;
using Twelve_weeks.Components;
using System.Diagnostics;
using Twelve_weeks.Models;
using Twelve_weeks.Enums;

public partial class Weeks : ContentPage
{
	public Weeks()
	{
		InitializeComponent();

        List<WeekModel> models = Singletone.InfoSaver.GetModelsList<WeekModel>(
            FileNamesEnum.FileNames.WeeksFileName
        ).ToList();

        models.Reverse();

        foreach (var model in models)
        {
            WeeksStackLayout.Children.Add(new WeekPanel(model));
        }

        //Debug.WriteLine(models[models.Count - 1].date.ToString());

        if (models.Count == 0 || models[models.Count - 1].date.DayNumber / 7 < DateOnly.FromDateTime(DateTime.Now).DayNumber / 7)
        {
            WeekModel model = new WeekModel() { date = DateOnly.FromDateTime(DateTime.Now), progress = 0 };
            WeeksStackLayout.Children.Add(new WeekPanel(model));
            Singletone.InfoSaver.SaveModel(model, FileNamesEnum.FileNames.WeeksFileName);
        }
    }
}