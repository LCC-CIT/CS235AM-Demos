using System;

namespace MathFlashCards
{
	public class MathQuiz
	{
		Random randGen;

		public MathQuiz ()
		{
			randGen = new Random ();
			MakeRandomNumbers ();
		}

		private int firstNumber = 0;
		private int secondNumber = 0;

		public int FirstNumber { get { return firstNumber; } }
		public int SecondNumber { get { return secondNumber; } }
		public int Sum { get { return firstNumber + secondNumber; } }

		public void MakeRandomNumbers()
		{
			firstNumber = randGen.Next (1, 101);
			secondNumber = randGen.Next (1, 101);
		}
	}
}

