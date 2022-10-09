namespace Twelve_weeks.Components;
using Twelve_weeks.Models;

public partial class DayPanel : ContentView
{
	private DayModel dayModel;

	public DayPanel()
	{
		InitializeComponent();
	}

	public DayPanel(DayModel model)
	{
        InitializeComponent();
		dayModel = model;	
    }

	private void ContentView_Loaded(object sender, EventArgs e)
	{
		BindingContext = dayModel;
	}

	private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		Singletone.DayDate = dayModel.date;
		AppShell.OpenPage(nameof(DayTasks), dayModel.date);
	}

	public DayModel DayModel
	{
		get
		{
			return dayModel;
		}
	}
}