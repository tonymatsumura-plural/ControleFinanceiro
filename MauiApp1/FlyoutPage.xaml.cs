namespace MauiApp1;

public partial class FlyoutPage 
{
	public FlyoutPage()
	{
		InitializeComponent();
	}

	private void btnSettings_Clicked(object sender, EventArgs e)
	{
		DisplayAlert("Settings", "Settings Clicked", "Ok");
	}
}