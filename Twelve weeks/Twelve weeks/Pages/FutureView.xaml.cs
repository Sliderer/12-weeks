namespace Twelve_weeks.Pages;

public partial class FutureView : ContentPage
{
	public FutureView()
	{
		InitializeComponent();
		FillEditors();
	}

	private void Editor_TextChanged(object sender, TextChangedEventArgs e)
	{
		SaveButton.IsVisible = true;
	}

	private async void SaveButton_Clicked(object sender, EventArgs e)
	{
		PopupsController.ShowAlert(this, "", "Saved!", "OK");
		await Task.Run(() => { Singletone.InfoSaver.SaveLongTermPlans(LongTermPlansEditor.Text); });
        await Task.Run(() => { Singletone.InfoSaver.SaveThreeYearPlans(ThreeYearsPlansEditor.Text); });
    }

	private void FillEditors()
	{
		LongTermPlansEditor.Text = Singletone.InfoSaver.GetLongTermPlans();
		ThreeYearsPlansEditor.Text = Singletone.InfoSaver.GetThreeYearPlans();
    }
}