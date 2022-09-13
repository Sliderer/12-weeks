namespace Twelve_weeks.Components;
using Twelve_weeks.Models;
using System.Diagnostics;

public partial class RoutineTask : ContentView
{
	private RoutineTaskModel model;
	public delegate void DeleteThisTaskDelegate(RoutineTask model);
	public event DeleteThisTaskDelegate deleteThisTask;

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
    }

	private void DeleteButton_Clicked(object sender, EventArgs e)
	{
		deleteThisTask?.Invoke(this);
    }

	public RoutineTaskModel Model
	{
		get
		{
			return model;
		}
	}
}