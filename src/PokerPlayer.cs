using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace Nancy.Simple
{
	public class Card {
		public static readonly string[] RANKS = { "2", "3", "4", "5", "6", "7", "8", "9", "J", "Q", "K", "A" };

		public string rank;
		public string suit;

		public override string ToString() {
			return String.Format("[Card {0} {1}]", this.suit, this.rank);
		}

		public int Value {
			get {
				return Array.IndexOf(RANKS, rank);
			}
		}
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
			Console.WriteLine(String.Format("Hole Cards: {0} {1}",
				currentPlayer.hole_cards[0], currentPlayer.hole_cards[1]));
			string communityCards = "";
			foreach (Card card in gameObject.community_cards) {
				communityCards += " " + card.ToString();
			}
			Console.WriteLine(String.Format("Community Cards:{0}", communityCards));

			if (currentPlayer.hole_cards[0].rank == currentPlayer.hole_cards[1].rank) {
				Console.WriteLine("action=all_in reason=pair raise={0}", gameObject.pot);
				return gameObject.current_buy_in + gameObject.pot;
			}

			if (currentPlayer.hole_cards[0].Value >= 9 && currentPlayer.hole_cards[1].Value >= 9) {
				Console.WriteLine("action=raise_with_min reason=high_cards raise={0}", gameObject.minimum_raise);
				return gameObject.current_buy_in + gameObject.minimum_raise;
			}

			Console.WriteLine("action=fold reason=no_good_hands");
			return 0;
		}

		public static void ShowDown(JObject gameState, GameObject gameObject)
		{
			Console.WriteLine("Showdown!");
		}
	}
}

