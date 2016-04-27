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

			Button button = FindViewById<Button> (Resource.Id.playButton);
			ImageView image = FindViewById<ImageView> (Resource.Id.rpsImage);

			// Get a new random hand image
			button.Click += delegate {
				GameLogic game = new GameLogic ();
				switch(game.ChooseHand())
				{
				case 1:
					image.SetImageResource(Resource.Drawable.Rock);
					break;
				case 2:
					image.SetImageResource(Resource.Drawable.Paper);
					break;
				case 3:
					image.SetImageResource(Resource.Drawable.Scissors);
					break;
				default:
					break;
				}
			};
		}
	}
}


