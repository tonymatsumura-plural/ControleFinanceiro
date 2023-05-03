using MauiApp1.Views;

namespace MauiApp1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new FlyoutPage();
		Routing.RegisterRoute(nameof(EditCardPage), typeof(EditCardPage));
		Routing.RegisterRoute(nameof(CardPage), typeof(CardPage));
		Routing.RegisterRoute(nameof(AddCardPage), typeof(AddCardPage));
	}
}
