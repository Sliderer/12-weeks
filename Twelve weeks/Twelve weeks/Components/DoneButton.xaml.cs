namespace Twelve_weeks.Components;

public partial class DoneButton : ContentView
{
	private Brush greenColor = Color.FromArgb("#55E9BC");
	private Brush creamColor = Color.FromArgb("#EEEEEE");
	public EventHandler tapped { get; set; }

	public DoneButton()
	{
		InitializeComponent();
	}

	private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
        SwitchMode();
		tapped.Invoke(sender, e);
	}

	public void SwitchMode()
	{
		CompleteImage.IsVisible = !CompleteImage.IsVisible;
	}
}