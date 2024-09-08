namespace MyFirstMAUIApp;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void BtnAbout_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new AboutPage());
        SemanticScreenReader.Announce(BtnAbout.Text);
    }
}

