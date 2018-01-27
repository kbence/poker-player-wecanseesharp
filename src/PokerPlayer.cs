using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace Nancy.Simple
{
	public class Card {
		public string rank;
		public string suit;
	}

	public class Player {
		public int id;
		public string name;
		public string status;
		public string version;
		public int stack;
		public int bet;
		public Card[] hole_cards;
	}

	public class GameObject {
		public int round;
		public int bet_index;
		public int small_blind;
		public int current_buy_in;
		public int pot;
		public int minimum_raise;
		public int dealer;
		public int orbits;
		public int in_action;
		public Player[] players;
		public Card[] community_cards;
	}

	public static class PokerPlayer
	{
		public static readonly string VERSION = "Default C# folding player";

		public static int BetRequest(JObject gameState, GameObject gameObject)
		{
			Player currentPlayer = gameObject.players[gameObject.in_action];
			Console.WriteLine(String.Format("Cards: {0}[{1}] {2}[{3}]",
				currentPlayer.hole_cards[0].suit, currentPlayer.hole_cards[0].rank,
				currentPlayer.hole_cards[1].suit, currentPlayer.hole_cards[1].rank));
			
			return 1000;
		}

		public static void ShowDown(JObject gameState, GameObject gameObject)
		{
			Console.WriteLine("Showdown!");
		}
	}
}

