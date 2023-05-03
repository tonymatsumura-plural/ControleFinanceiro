using MauiApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data;

public class CardsDatabase
{
	static SQLiteAsyncConnection Database;

	public static readonly AsyncLazy<CardsDatabase> Instance =
		new AsyncLazy<CardsDatabase>(async () =>
		{
			var instance = new CardsDatabase();
			try
			{
				CreateTableResult result = await Database.CreateTableAsync<Card>();
			}
			catch (Exception)
			{
				throw;
			}
			return instance;
		});

    public CardsDatabase()
    {
		Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
    }
	public Task<List<Card>> GetCardsAsync()
	{
		return Database.Table<Card>().ToListAsync();
	}
	public Task<Card> GetItemAsync(int id)
	{
		return Database.Table<Card>().Where(i => i.Id == id).FirstOrDefaultAsync();
	}	
	public Task<int> SaveCardAsync(Card card)
	{
		return (card.Id != 0) ? Database.UpdateAsync(card) : Database.InsertAsync(card);
	}
	public Task<int> DeleteCardAsync(Card card)
	{
		return Database.DeleteAsync(card);
	}
}
