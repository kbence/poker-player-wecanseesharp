﻿using System;

namespace Nancy.Simple {
	public class ActionLogger {
		private GameObject gameObject;

		public ActionLogger(GameObject gameObject) {
			this.gameObject = gameObject;
		}

		public void Cards() {
			Player player = gameObject.players[gameObject.in_action];
			string communityCards = "";

			foreach (Card card in gameObject.community_cards) {
				communityCards += " " + card.ToString();
			}

			Console.WriteLine("Cards: {0} {1} |{2}", player.hole_cards[0], player.hole_cards[1], communityCards);
		}

		public void Fold(string reason) {
			Cards();
			Console.WriteLine("game={0} reason={1}", gameObject.game_id, reason);
		}

		public void Raise(string reason, int raise) {
			Cards();
			Console.WriteLine("game={0} reason={1}", gameObject.game_id, reason, raise);
		}

		public void AllIn(string reason, int raise) {
			Cards();
			Console.WriteLine("game={0} reason={1}", gameObject.game_id, reason, raise);
		}
	}
}

