namespace Twelve_weeks;
using Twelve_weeks.Saving;


public partial class App : Application
{
	private static App instance;

	public App()
	{
		InitializeComponent();
		instance = this;
#if ANDROID
		MainActivity.SetStatusBarLight(false);
#endif
		MainPage = new AppShell();
    }

    public async static void ChangePage(ContentPage page)
	{
		await Shell.Current.GoToAsync(nameof(page));
	}
}
