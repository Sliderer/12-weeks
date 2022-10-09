namespace Twelve_weeks.Components;
using Twelve_weeks.Models;
using System.Diagnostics;

public partial class RoutineTask : ContentView
{
	private RoutineTaskModel model;
	public delegate void DeleteThisTaskDelegate(RoutineTask model);
	public event DeleteThisTaskDelegate deleteThisTask;
    public event DeleteThisTaskDelegate changeCompletion;

    public RoutineTask()
	{
		InitializeComponent();
	}

	public RoutineTask(RoutineTaskModel model)
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
        changeCompletion.Invoke(this);
        //System.Diagnostics.Debug.WriteLine("CHANGE");
    }

    public RoutineTaskModel Model
	{
		get
		{
			return model;
		}
	}
}