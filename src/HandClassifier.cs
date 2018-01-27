using System;
using System.Collections.Generic;

namespace Nancy.Simple {
	public class Hand {
		public Card[] HoleCards;
		public Card[] CommunityCards;

		public Hand(Card[] holeCards, Card[] communityCards) {
			this.HoleCards = holeCards;
			this.CommunityCards = communityCards;
		}

		public Card[] AllCards {
			get {
				Card[] cards = new Card[HoleCards.Length + CommunityCards.Length];
				HoleCards.CopyTo(cards, 0);
				CommunityCards.CopyTo(cards, HoleCards.Length);

				return cards;
			}
		}

		public bool HasFlush() {
			Dictionary<string, List<Card>> cardsBySuit = new Dictionary<string, List<Card>>();

			foreach (Card card in AllCards) {
				if (!cardsBySuit.ContainsKey(card.suit)) {
					cardsBySuit[card.suit] = new List<Card>();
				}

				cardsBySuit[card.suit].Add(card);
			}

			foreach (KeyValuePair<string, List<Card>> cards in cardsBySuit) {
				if (cards.Value.Count >= 5) {
					return true;
				}
			}

			return false;
		}

		private Dictionary<string, List<Card>> GetCardsByRank() {
			Dictionary<string, List<Card>> cardsByRank = new Dictionary<string, List<Card>>();

			foreach (Card card in AllCards) {
				if (!cardsByRank.ContainsKey(card.rank)) {
					cardsByRank[card.rank] = new List<Card>();
				}

				cardsByRank[card.rank].Add(card);
			}

			return cardsByRank;
		}

		public bool HasPair() {
			foreach (KeyValuePair<string, List<Card>> pair in GetCardsByRank()) {
				if (pair.Value.Count == 2) {
					return true;
				}
			}

			return false;
		}

		public bool HasPairs() {
			int pairs = 0;

			foreach (KeyValuePair<string, List<Card>> pair in GetCardsByRank()) {
				if (pair.Value.Count == 2) {
					pairs++;
				}
			}

			return pairs >= 2;
		}

		public bool HasThreeOfAKind() {
			foreach (KeyValuePair<string, List<Card>> pair in GetCardsByRank()) {
				if (pair.Value.Count == 3) {
					return true;
				}
			}

			return false;
		}
	}

	public class RankComparer : IComparer<Card> {
		public int Compare(Card hand1, Card hand2) {
			return 0;
		}
	}

	public class HandClassifier {
		public HandClassifier() {
		}

		public void Classify(Hand hand) {
			Card[] cards = hand.AllCards;
			Array.Sort<Card>(cards, new RankComparer());
		}
	}
}

