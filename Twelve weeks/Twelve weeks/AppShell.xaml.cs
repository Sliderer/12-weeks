namespace Twelve_weeks;

using Twelve_weeks.Components;
using Twelve_weeks.Pages;
using Twelve_weeks.Saving;

public partial class AppShell : Shell
{
    private Singletone singletone;


    public AppShell()
	{
		InitializeComponent();
    
        Routing.RegisterRoute(nameof(Routine), typeof(Routine));
        Routing.RegisterRoute(nameof(Days), typeof(Days));
        Routing.RegisterRoute(nameof(WeekPlans), typeof(WeekPlans));
        Routing.RegisterRoute(nameof(YearPlans), typeof(YearPlans));
        Routing.RegisterRoute(nameof(Life), typeof(Life));
        Routing.RegisterRoute(nameof(FutureView), typeof(FutureView));
        Routing.RegisterRoute(nameof(DayTasks), typeof(DayTasks));
        singletone = new Singletone(new FileSaver(), new DatesSaver());
    }

    private void Shell_Loaded(object sender, EventArgs e)
    {

    }

    public static void OpenPage(ShellNavigationState state)
    {
        Shell.Current.GoToAsync(state);
    }

    public static void OpenPage(ShellNavigationState state, DateOnly dayDate)
    {
        Singletone.DayDate = dayDate;
        Shell.Current.GoToAsync(state);
    }
}