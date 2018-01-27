using System;

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
	}

	public class HandClassifier {
		public HandClassifier() {
		}

		public void Classify(Hand hand) {}
	}
}

