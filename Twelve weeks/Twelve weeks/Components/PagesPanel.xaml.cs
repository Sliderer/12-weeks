namespace Twelve_weeks;
using Twelve_weeks.Pages;

public partial class PagesPanel : ContentView
{
	public PagesPanel()
	{
		InitializeComponent();
	
	}

	private void ContentView_Loaded(object sender, EventArgs e)
	{
        PagesButtonStackLayout.Children.Add(new PageButton("Routine", new Routine()));
        PagesButtonStackLayout.Children.Add(new PageButton("Day", new Days()));
        PagesButtonStackLayout.Children.Add(new PageButton("Week plans", new Weeks()));
        PagesButtonStackLayout.Children.Add(new PageButton("Year plans", new YearPlans()));
        PagesButtonStackLayout.Children.Add(new PageButton("Life", new Life()));
        PagesButtonStackLayout.Children.Add(new PageButton("Future view", new FutureView()));
    }
}