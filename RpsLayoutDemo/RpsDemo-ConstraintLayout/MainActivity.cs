using Android.App;
using Android.Widget;
using Android.OS;
using RpsDemo;

namespace RpsDemoConstraintLayout
{
    [Activity(Label = "RpsDemo-ConstraintLayout", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var playButton = FindViewById<Button>(Resource.Id.playButton);
            var rpsImageView = FindViewById<ImageView>(Resource.Id.rpsImage);
            var rpsEditText = FindViewById<EditText>(Resource.Id.rpsEditText);
            var winnerTextView = FindViewById<TextView>(Resource.Id.winnerTextView);

            // Get a new random hand image
            playButton.Click += delegate {
                GameLogic game = new GameLogic();
                switch (game.ChooseHand())
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

