using MauiApp1.Data;
using Card = MauiApp1.Models.Card;

namespace MauiApp1.Views;
[QueryProperty(nameof(CardId), "Id")]
public partial class EditCardPage : ContentPage
{
	private Card _card;
	private Card _cardFromDb;
	private int idFromUrl = -1;
	private CardsDatabase database;
	public EditCardPage()
	{
		InitializeComponent();
		GetDatabase();		
	}

	async void LoadCard(int id)
	{
		_cardFromDb = await database.GetItemAsync(id);
		var _tempCard = await database.GetItemAsync(idFromUrl);
		
		if (_cardFromDb != null)
		{
			cardCtrl.Nome = _tempCard.Nome;
			cardCtrl.Gasto = _tempCard.Gasto.ToString();
			cardCtrl.TetoGastos = _tempCard.TetoGastos.ToString();
		}
	}
	async void GetCardById(int id)
	{
		_cardFromDb = await database.GetItemAsync(id);
	}
	private async void GetDatabase()
	{
		database = await CardsDatabase.Instance;
	}
	public string CardId
	{
		set
		{
			idFromUrl = int.Parse(value);
			//_card = FonteDados.GetCardById(idFromUrl);
			
			//***			
			LoadCard(idFromUrl);			
		}
	}	
	
	private async void btnUpdateCard_Clicked(object sender, EventArgs e)
	{
		_cardFromDb.Nome = cardCtrl.Nome;
		_cardFromDb.Gasto = int.Parse(cardCtrl.Gasto);
		_cardFromDb.TetoGastos = int.Parse(cardCtrl.TetoGastos);

		//FonteDados.UpdateCard(_card);
		await database.SaveCardAsync(_cardFromDb);

		await Shell.Current.GoToAsync("..");

	}
	private async void btn_OnCancel(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}
	private async void cardCtrl_OnError(object sender, string e)
	{
		await DisplayAlert("Error", e, "Ok");
	}
}