using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

// MathFlashCards v2

namespace MathFlashCards
{
    [Activity(Label = "Back", ParentActivity = typeof(FrontActivity))]
    public class BackActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Back);

            int answer = Intent.Extras.GetInt(FrontActivity.EXTRA_ANSWER);
            var answerTextView = FindViewById<TextView>(Resource.Id.answerTextView);
            answerTextView.Text = answer.ToString();

            Button rightButton = FindViewById<Button>(Resource.Id.rightButton);
            rightButton.Click += delegate {
                ResultToFront(true);
            };

            Button wrongButton = FindViewById<Button>(Resource.Id.wrongButton);
            wrongButton.Click += delegate {
                ResultToFront(false);
            };
        }

        private void ResultToFront(bool right)
        {
            var toFront = new Intent(this, typeof(FrontActivity));
            toFront.PutExtra(FrontActivity.EXTRA_RIGHT, right);
            SetResult(Result.Ok, toFront);
            Finish();

        }
    }
}

