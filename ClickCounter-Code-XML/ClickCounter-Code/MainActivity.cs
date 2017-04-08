using Android.App;
using Android.Widget;
using Android.OS;

namespace ClickCounterCode
{
	[Activity(Label = "@string/app_name", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 0;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create the UI in code
			var layout = new LinearLayout(this);
			layout.Orientation = Orientation.Vertical;

			var aLabel = new TextView(this);
			aLabel.SetText(Resource.String.label_text);

			var aButton = new Button(this);
			aButton.SetText(Resource.String.button_text);

			// Add an event handler
			aButton.Click += (sender, e) =>
			{
				aLabel.Text = (++count).ToString() + " taps";
			};

			// Add widgets to the layout and the layout to this activity
			layout.AddView(aLabel);
			layout.AddView(aButton);
			SetContentView(layout);
		}
	}
}

