using Card = MauiApp1.Models.Card;
using MauiApp1.Data;
using System.Collections.ObjectModel;

namespace MauiApp1.Views;

public partial class CardPage : ContentPage
{
	public CardPage() => InitializeComponent();	
	
	protected override void OnAppearing() 
	{
		base.OnAppearing();
		LoadCards();
	}
	private async void ListCards_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (listCards.SelectedItem != null) 
		{
			//	await Shell.Current.GoToAsync($"{nameof(EditCardPage)}?Id={((Card)listCards.SelectedItem).Id}");
			var _card = (Card)listCards.SelectedItem;

			string result = await DisplayPromptAsync("Gasto", "Valor?", keyboard: Keyboard.Telephone);
			
			if (result != null)
			{
				
				if (int.Parse(result) < 0)
				{
					await DisplayAlert("Error", "Valor inválido", "Ok");
					return;
				}
				else
				{
					// ***
					var totalGastos = _card.Gasto + int.Parse(result);

					if (totalGastos > _card.TetoGastos)
					{
						await DisplayAlert("Alerta", $"O limite de gastos foi ultrapassado. Operação inválida.Gasto máximo = {_card.TetoGastos- _card.Gasto}", "OK");
					}
					else
					{
						//***
						_card.Gasto += int.Parse(result);						
						//FonteDados.UpdateCard(_card);
						CardsDatabase database = await CardsDatabase.Instance;
						var _cards = await database.SaveCardAsync(_card);
						LoadCards();
					} //else
				} // else			
			} // if					
		} 
	}
	private void ListCards_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		listCards.SelectedItem = null;
	}
	private async void BtnAddCardPage_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync($"{nameof(AddCardPage)}");
	}
	private async void MenuItem_DeleteClicked(object sender, EventArgs e)
	{
		bool answer = await DisplayAlert("Deletar cartão?", "Deseja deletar cartão", "Sim", "Não");
		if (answer)
		{
			var menuItem = sender as MenuItem;
			var card = menuItem.CommandParameter as Card;
			//FonteDados.DeleteCard(card);
			CardsDatabase database = await CardsDatabase.Instance;
			var _cards = database.DeleteCardAsync(card);
			LoadCards();
		}
	} 
	private async void LoadCards()
	{
		//var _cards = new ObservableCollection<Card>(FonteDados.GetCards());
		//***
		CardsDatabase database = await CardsDatabase.Instance;
		var _cards = database.GetCardsAsync().Result;
		_cards = _cards.OrderBy(x => x.Nome).ToList();
		listCards.ItemsSource = _cards;
	}
	private async void MenuItem_EditCardClicked(object sender, EventArgs e)
	{
		var menuItem = sender as MenuItem;
		var card = menuItem.CommandParameter as Card;
		await Shell.Current.GoToAsync($"{nameof(EditCardPage)}?Id={card.Id}");
	}
}