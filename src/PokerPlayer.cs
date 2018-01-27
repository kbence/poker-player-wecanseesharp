﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "The folding machine";

		public static int BetRequest(JObject gameState, GameObject gameObject)
		{
			ActionLogger log = new ActionLogger(gameObject);
			int call = gameObject.current_buy_in - gameObject.players[gameObject.in_action].bet;

			Player currentPlayer = gameObject.players[gameObject.in_action];
			string communityCards = "";
			foreach (Card card in gameObject.community_cards) {
				communityCards += " " + card.ToString();
			}

			if (currentPlayer.hole_cards[0].rank == currentPlayer.hole_cards[1].rank &&
				currentPlayer.hole_cards[0].Value > 9)
			{
				log.AllIn("high_pair", gameObject.pot);
				return call + gameObject.pot;
			}

			if (currentPlayer.hole_cards[0].rank == currentPlayer.hole_cards[1].rank) {
				log.Raise("pair", gameObject.pot);
				return call + gameObject.minimum_raise * 2;
			}

			if (currentPlayer.hole_cards[0].Value > 9 && currentPlayer.hole_cards[1].Value > 9) {
				log.Raise("high_cards", gameObject.minimum_raise);
				return call + gameObject.minimum_raise;
			}

			log.Fold("no_good_hands");
			return 0;
		}

		public static void ShowDown(JObject gameState, GameObject gameObject)
		{
			Console.WriteLine("Showdown!");
		}
	}
}

