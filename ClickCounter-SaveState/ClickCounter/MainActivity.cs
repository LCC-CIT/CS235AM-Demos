using Android.App;
using Android.Widget;
using Android.OS;

namespace ClickCounter
{
    [Activity(Label = "ClickCounter", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 0;   // start the count at zero, not 1
        const string COUNTER_KEY = "Counter";
		Button button;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += delegate {
				count++;
				ShowCount();
            };

			// If a count has been saved, use it
            if (bundle != null)
            {
				int savedCount = bundle.GetInt(COUNTER_KEY, -1);
				// only use the saved count if it has been incremented at least once
				if (savedCount > 0)  
				{
					count = savedCount;
					ShowCount();
				}
            }
        }

		// We do this more than once, let's keep the code DRY
		private void ShowCount()
		{
                button.Text = string.Format("{0} clicks!", count);
		}

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt(COUNTER_KEY, count);
        }
    }
}

