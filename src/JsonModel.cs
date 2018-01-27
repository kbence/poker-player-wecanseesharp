using System;

namespace Nancy.Simple {
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

		override public string ToString() {
			return String.Format("[Player name={0} money={1}/{2}]", name, bet, stack);
		}
	}

	public class GameObject {
		public string tournament_id;
		public string game_id;
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
}

