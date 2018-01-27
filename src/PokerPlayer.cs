using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "The shitting machine";

		public static int BetRequest(JObject gameState, GameObject gameObject)
		{
			ActionLogger log = new ActionLogger(gameObject);
			int call = gameObject.current_buy_in - gameObject.players[gameObject.in_action].bet;

			Player currentPlayer = gameObject.players[gameObject.in_action];
			string communityCards = "";
			foreach (Card card in gameObject.community_cards) {
				communityCards += " " + card.ToString();
			}

			var hand = gameObject.CurrentHand;

			if (hand.HasFlush()) {
				log.Raise("flush", gameObject.minimum_raise * 5);
				return call + gameObject.minimum_raise * 5;
			}

			if (hand.HasPair() && hand.HasThreeOfAKind()) {
				log.Raise("full_house", gameObject.minimum_raise * 3);
				return call + gameObject.minimum_raise * 3;
			}

			if (currentPlayer.hole_cards[0].rank == currentPlayer.hole_cards[1].rank &&
				currentPlayer.hole_cards[0].Value > 10)
			{
				log.Raise("high_pair", gameObject.minimum_raise * 2);
				return call + gameObject.minimum_raise * 2;
			}

			if (currentPlayer.hole_cards[0].rank == currentPlayer.hole_cards[1].rank) {
				log.Raise("pair", gameObject.minimum_raise);
				return call + gameObject.minimum_raise;
			}

			if (currentPlayer.hole_cards[0].Value > 9 && currentPlayer.hole_cards[1].Value > 9) {
				log.Raise("high_cards", gameObject.minimum_raise);
				return call;
			}

			log.Fold("no_good_hands");
			return 0;
		}

		public static void ShowDown(JObject gameState, GameObject gameObject)
		{
			ActionLogger log = new ActionLogger(gameObject);
			log.Players();
		}
	}
}

