using Twelve_weeks.Models;
using Twelve_weeks.Pages;

namespace Twelve_weeks.Components;

public partial class WeekPanel : ContentView
{
    private WeekModel model;

    public WeekPanel()
    {
        InitializeComponent();
    }

    public WeekPanel(WeekModel model)
    {
        InitializeComponent();
        this.model = model;
    }

    private void ContentView_Loaded(object sender, EventArgs e)
    {
        BindingContext = model;
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Singletone.DayDate = model.date;
        AppShell.OpenPage(nameof(WeekTasks), model.date);
    }
}