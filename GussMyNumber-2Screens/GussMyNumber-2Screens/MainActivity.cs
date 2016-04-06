using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace GussMyNumber2Screens
{
	[Activity (Label = "Guss My Number Game", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Main);

			EditText guessEditText;
			guessEditText = FindViewById<EditText> (Resource.Id.guessEditText);
			Button button = FindViewById<Button> (Resource.Id.myButton);

			// Start second activity and send it the number guessed
			button.Click += delegate {
				var second = new Intent(this, typeof(SecondActivity));
				second.PutExtra("Guess", guessEditText.Text );
				StartActivity(second);
			};
		}
	}
}


