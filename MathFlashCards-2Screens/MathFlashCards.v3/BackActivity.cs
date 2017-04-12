using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

// MathFlashCards v2

namespace MathFlashCards
{
    [Activity(Label = "Card back")]
    public class BackActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Back);

            // Display the answer that was sent frmo the front
            int answer = Intent.Extras.GetInt(FrontActivity.EXTRA_ANSWER);
            var answerTextView = FindViewById<TextView>(Resource.Id.answerTextView);
            answerTextView.Text = answer.ToString();

            // Send a boolean true to the front
            Button rightButton = FindViewById<Button>(Resource.Id.rightButton);
            rightButton.Click += delegate {
                ResultToFront(true);
            };

            // Send a boolean false to the front
            Button wrongButton = FindViewById<Button>(Resource.Id.wrongButton);
            wrongButton.Click += delegate {
                ResultToFront(false);
            };
        }

        // This is a helper method that does the work of putting a value in an intent and sending it
        private void ResultToFront(bool right)
        {
            var toFront = new Intent(this, typeof(FrontActivity));
            toFront.PutExtra(FrontActivity.EXTRA_RIGHT, right);
            SetResult(Result.Ok, toFront);
            Finish();
        }
    }
}

