using System;

namespace MathFlashCards
{
	public class MathQuiz
	{
		Random randGen = new Random();

		public MathQuiz ()
		{
			MakeRandom ();
		}
		
		private int firstNumber = 0;
		private int secondNumber = 0;

		public int FirstNumber { get { return firstNumber; } }
		public int SecondNumber { get { return secondNumber; } }

		public void MakeRandom()
		{
			firstNumber = randGen.Next (0, 101);
			secondNumber = randGen.Next (0, 101);
		}

		public int CalcSum()
		{
			return firstNumber + secondNumber;
		}

	}
}

