using System;

namespace Nancy.Simple {
	public class BetHandler : IBet {
		private GameObject gameObject;

		public BetHandler(GameObject gameObject) {
			this.gameObject = gameObject;
		}

        public void ProcessBet()
        {

        }
	}
}

