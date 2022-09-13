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
			FileNamesEnum.FileNames.LastEnterFileName
		).ToList();

		//Debug.WriteLine("START");
		//DayModel DayModel = new DayModel() { progress = 0 };
		//DayModel.GetJsonString();
		//foreach (var model in models)
		//{
		//	model.GetJsonString();
		//}
		foreach (DayModel model in models)
		{
			
			DaysStackLayout.Children.Add(new DayPanel(model));
		}


		if (models.Count == 0 || models[models.Count - 1].date < DateOnly.FromDateTime(DateTime.Now))
		{
			DayModel dayModel = new DayModel() { date = DateOnly.FromDateTime(DateTime.Now), progress = 0 };
			DaysStackLayout.Children.Add(new DayPanel(dayModel));
			Singletone.InfoSaver.SaveModel(dayModel, FileNamesEnum.FileNames.LastEnterFileName);
		}
	}
}