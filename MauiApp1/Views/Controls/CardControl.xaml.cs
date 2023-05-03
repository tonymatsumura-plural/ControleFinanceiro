using MauiApp1.Data;

namespace MauiApp1.Views.Controls;

public partial class CardControl : ContentView
{
	public event EventHandler<string> OnError;
	public event EventHandler<EventArgs> OnSave;
	public event EventHandler<EventArgs> OnCancel;
	
	public CardControl()
	{
		InitializeComponent();
	}	
	public string Nome
	{
		get
		{
			return entryNome.Text;
		}
		set
		{
			entryNome.Text = value;
		}
	}
	public string Gasto
	{
		get
		{
			return entryGasto.Text;
		}
		set
		{
			entryGasto.Text = value;
		}
	}
	public string TetoGastos
	{
		get
		{
			return entryTetoGastos.Text;
		}
		set
		{
			entryTetoGastos.Text = value;
		}
	}
	private void btnSave_Clicked(object sender, EventArgs e)
	{
		if (nameValidator.IsNotValid)
		{

			OnError?.Invoke(sender, "Nome inválido");
			return;
		}

		if (TetoGastosValidator.IsNotValid)
		{
			OnError?.Invoke(sender, "Teto de gastos inválido");
			return;
		}

		if (GastoValidator.IsNotValid)
		{
			OnError?.Invoke(sender, "Gasto inválido");
			return;
		}

		OnSave?.Invoke(sender, e);

		//var _cardToUpdate = new Card();
		//_cardToUpdate.Id = _card.Id;
		//_cardToUpdate.Nome = entryNome.Text;
		//_cardToUpdate.Gasto = int.Parse(entryGasto.Text);
		//_cardToUpdate.TetoGastos = int.Parse(entryTetoGastos.Text);
		//FonteDados.UpdateCard(_cardToUpdate);
		//Shell.Current.GoToAsync("..");
	}
	private void btnCancel_Clicked(object sender, EventArgs e)
	{
		OnCancel?.Invoke(sender, e);
	}
}
