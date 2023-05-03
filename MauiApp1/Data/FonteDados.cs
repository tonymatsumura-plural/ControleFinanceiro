using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Models;

namespace MauiApp1.Data;

public static class FonteDados
{
	public static List<Card> _cards = new()
	{
		new Card { Id=0, Nome = "Nubank", Gasto = 0, TetoGastos = 100 },
		new Card { Id=1, Nome = "Visa", Gasto = 0, TetoGastos = 100 },
		new Card { Id=2, Nome = "Mastercard", Gasto = 0, TetoGastos = 100 },
	};

	// ---------- GET ALL CARDS ----------  
	public static List<Card> GetCards() => _cards;

	// ---------- GET CARD BY ID ----------
	public static Card GetCardById(int cardId)
	{
		var card = _cards.FirstOrDefault(c => c.Id == cardId);

		if (card != null)
		{
			return new Card
			{
				Id = cardId,
				Nome = card.Nome,
				Gasto = card.Gasto,
				TetoGastos = card.TetoGastos				
			};
		}

		return null;		
	}

	// ----------GET CARD INDEX ----------
	public static int GetCardIndex(int cardId)
	{
		return _cards.FindIndex(c => c.Id == cardId);
	}
	
	// ---------- CREATE NEW CARD ----------
	public static void AddCard(Card card)
	{
		var maxId = _cards.Max(c => c.Id);
		card.Id = maxId + 1;
		_cards.Add(card);
		Console.WriteLine(_cards);

	}
	
	// ---------- UPDATE CARD ----------
	public static void UpdateCard(Card card)
	{
		var cardIndex = GetCardIndex(card.Id);

		if (cardIndex > -1)
		{
			_cards[cardIndex] = card;
		}
	}

	// ---------- DELETE CARD ----------
	public static void DeleteCard(Card card)
	{
		_cards.Remove(card);
	}

	// ---------- GASTO ----------
	public static void Gasto(int valor, Card card)
	{
		var cardIndex = GetCardIndex(card.Id);

		_cards[cardIndex].Gasto += valor;

	}
}
