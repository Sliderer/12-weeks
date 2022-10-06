namespace Twelve_weeks.Components;

using Android.OS;
using System.Diagnostics;
using System.Threading.Tasks;
using Twelve_weeks.Models;

public partial class WeekTask : ContentView
{
    private WeekTaskModel model;
    public delegate void DeleteThisTaskDelegate(WeekTask model);
    public event DeleteThisTaskDelegate deleteThisTask;
    public event DeleteThisTaskDelegate changeCompletion;


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
        DoneButton.tapped += ChangeCompletion;
        if (model.isDone)
        {
            DoneButton.SwitchMode();
        }
        //System.Diagnostics.Debug.WriteLine($"Model {model.title}: {model.isDone}");
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


    public WeekTaskModel Model
    {
        get
        {
            return model;
        }
    }
}