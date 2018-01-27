using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace Nancy.Simple
{
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

