namespace MyFirstMAUIApp;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    private void BtnSample_Clicked(object sender, EventArgs e)
    {
		lblSample.Text = txtSample.Text.Trim();
    }
}