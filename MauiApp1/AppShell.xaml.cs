using MauiApp1.Views;

namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(EditCardPage), typeof(EditCardPage));
		Routing.RegisterRoute(nameof(CardPage), typeof(CardPage));
		Routing.RegisterRoute(nameof(AddCardPage), typeof(AddCardPage));
	}
}
