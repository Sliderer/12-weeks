namespace Twelve_weeks.Components;
using Twelve_weeks.Models;

public partial class WeekTask : ContentView
{
    private WeekTaskModel model;
    public delegate void DeleteThisTaskDelegate(WeekTask model);
    public event DeleteThisTaskDelegate deleteThisTask;

    public WeekTask()
    {
        InitializeComponent();
    }

    public WeekTask(WeekTaskModel model)
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


    public WeekTaskModel Model
    {
        get
        {
            return model;
        }
    }
}