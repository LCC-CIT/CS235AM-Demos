using System;

namespace RpsDemo
{

	public enum handShape {rock, paper, scissors}

	public class GameLogic
	{
		Random rand = new Random();
		handShape androidHand;

		/// <summary>
		/// Randomly chooses a number to represent a hand position.
		/// </summary>
		/// <returns>1 for rock, 2 for paper, 3 for scissors.</returns>
		public handShape ChooseHand()
		{
			androidHand = (handShape)rand.Next(3);
			return androidHand;  // produces random 0 through 2
		}


		// does the choice entered by the user beat the random (android) one?
		public string didUserWin(string hand)
		{
			// Convert the user's hand shape choice to an enum
			handShape userHand = (handShape)Enum.Parse (typeof(handShape), hand.ToLower());
			if (userHand == androidHand)
				return "Tie";
			else if ((userHand == handShape.rock && androidHand == handShape.scissors) ||
				(userHand > androidHand && !(androidHand == handShape.rock && userHand == handShape.scissors)))
				return "You win!";
			else
				return "Android wins";
		}
	}
}

