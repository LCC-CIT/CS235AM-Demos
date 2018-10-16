using Android.App;
using Android.Widget;
using Android.OS;
using RpsDemo;

namespace RpsDemoRelativeLayout
{
	[Activity (Label = "RpsDemo-RelativeLayout", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.activity_main);

			var playButton = FindViewById<Button> (Resource.Id.playButton);
			var rpsImageView = FindViewById<ImageView> (Resource.Id.rpsImage);
            var compMoveTextView = FindViewById<TextView>(Resource.Id.compMoveTextView);
			var rpsEditText = FindViewById<EditText> (Resource.Id.rpsEditText);
			var winnerTextView = FindViewById<TextView> (Resource.Id.winnerTextView);

			// Get a new random hand image
			playButton.Click += delegate {
				GameLogic game = new GameLogic ();
                HandShape compMove = game.ChooseHand();
                compMoveTextView.Text = compMove.ToString();

				switch(compMove)
				{
				case HandShape.rock:
					rpsImageView.SetImageResource(Resource.Drawable.Rock);
					break;
				case HandShape.paper:
					rpsImageView.SetImageResource(Resource.Drawable.Paper);
					break;
				case HandShape.scissors:
					rpsImageView.SetImageResource(Resource.Drawable.Scissors);
					break;
				default:
					break;
				}

				// See if the user won
				if (rpsEditText.Text != "")
					winnerTextView.Text = game.didUserWin(rpsEditText.Text);
			};
		}
	}
}

