namespace Twelve_weeks.Components;
using Twelve_weeks.Models;

public partial class DayTask : ContentView
{
	private DayTaskModel model;
    public delegate void DeleteThisTaskDelegate(DayTask model);
    public event DeleteThisTaskDelegate deleteThisTask;
    public event DeleteThisTaskDelegate changeCompletion;

    public DayTask()
	{
		InitializeComponent();
	}

	public DayTask(DayTaskModel model)
	{
        InitializeComponent();
		this.model = model;
    }

	private void ContentView_Loaded(object sender, EventArgs e)
	{
		BindingContext = model;
        DoneButton.tapped += ChangeCompletion;
        if (model.isDone)
        {
            DoneButton.SwitchMode();
        }
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        deleteThisTask?.Invoke(this);
    }

    public void ChangeCompletion(object sender, EventArgs e)
    {
        changeCompletion?.Invoke(this);
        //System.Diagnostics.Debug.WriteLine("CHANGE");
    }

    public void SwitchDoneButtonColor()
    {
        DoneButton.SwitchMode();
    }

    public DayTaskModel Model
	{
		get
		{
			return model;
		}
	}
}