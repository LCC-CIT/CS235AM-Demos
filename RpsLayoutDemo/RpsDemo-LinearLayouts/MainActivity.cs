using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RpsDemo
{
	[Activity (Label = "Rock, Paper, Scissors", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		GameLogic game = new GameLogic ();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			var playButton = FindViewById<Button> (Resource.Id.playButton);
			var handImageView = FindViewById<ImageView> (Resource.Id.handImageView);
			var rpsEditText = FindViewById<EditText> (Resource.Id.rpsEditText);
			var answerTextView = FindViewById<TextView> (Resource.Id.answerTextView);

			// Get a new random hand image
			playButton.Click += delegate {
				switch(game.ChooseHand())
				{
				case handShape.rock:
					handImageView.SetImageResource(Resource.Drawable.Rock);
					break;
				case handShape.paper:
					handImageView.SetImageResource(Resource.Drawable.Paper);
					break;
				case handShape.scissors:
					handImageView.SetImageResource(Resource.Drawable.Scissors);
					break;
				default:
					break;
				}

				// See if the user won
				if (rpsEditText.Text != "")
					answerTextView.Text = game.didUserWin(rpsEditText.Text);
			};
				
		}
	}
}


