namespace Twelve_weeks;

public partial class PageButton : ContentView
{
	private string pageTitle;
	private ContentPage contentPage;

	public ContentPage ContentPage
	{
		get { return contentPage; }
		set { contentPage = value; }
	}

	public string PageTitle
	{
		get
		{
			return pageTitle;
		}
		set
		{
			pageTitle = value;
		}
	}

	public PageButton()
	{
		InitializeComponent();
	}

	public PageButton(string pageTitle, ContentPage page)
	{
        InitializeComponent();
		this.PageTitle = pageTitle;
		this.ContentPage = page;

    }

	private void ContentView_Loaded(object sender, EventArgs e)
	{
        BindingContext = this;
    }

	private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
        App.ChangePage(ContentPage);
    }
}