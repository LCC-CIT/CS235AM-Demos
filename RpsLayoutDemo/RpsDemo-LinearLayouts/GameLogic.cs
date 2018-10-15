using System;

namespace RpsDemo
{

	public enum HandShape {rock, paper, scissors}

	public class GameLogic
	{
		Random rand = new Random();
		HandShape androidHand;

		/// <summary>
		/// Randomly chooses a number to represent a hand position.
		/// </summary>
		/// <returns>1 for rock, 2 for paper, 3 for scissors.</returns>
		public HandShape ChooseHand()
		{
			androidHand = (HandShape)rand.Next(3);
			return androidHand;  // produces random 0 through 2
		}


		// does the choice entered by the user beat the random (android) one?
		public string didUserWin(string hand)
		{
			// Convert the user's hand shape choice to an enum
			HandShape userHand = (HandShape)Enum.Parse (typeof(HandShape), hand.ToLower());
			if (userHand == androidHand)
				return "Tie";
			else if ((userHand == HandShape.rock && androidHand == HandShape.scissors) ||
				(userHand > androidHand && !(androidHand == HandShape.rock && userHand == HandShape.scissors)))
				return "You win!";
			else
				return "Android wins";
		}
	}
}

