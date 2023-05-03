using MauiApp1.Data;

namespace MauiApp1.Views;

public partial class AddCardPage : ContentPage
{
	public AddCardPage() => InitializeComponent();

	private async void cardCtrl_OnSave(object sender, EventArgs e)
	{
		Models.Card card = new()
		{
			Nome = cardCtrl.Nome,
			Gasto = decimal.Parse(cardCtrl.Gasto),
			TetoGastos = decimal.Parse(cardCtrl.TetoGastos)
		};

		FonteDados.AddCard(new Models.Card
		{
			Nome = cardCtrl.Nome,
			Gasto = decimal.Parse(cardCtrl.Gasto),
			TetoGastos = decimal.Parse(cardCtrl.TetoGastos)
		});

		//***
		CardsDatabase database = await CardsDatabase.Instance;
		await database.SaveCardAsync(card);

		var cards = database.GetCardsAsync().Result;

		await Shell.Current.GoToAsync("..");

	}

	private void cardCtrl_OnCancel(object sender, EventArgs e)
	{

	}

	private void cardCtrl_OnError(object sender, string e)
	{
		DisplayAlert("Error", e, "Ok");
	}
}