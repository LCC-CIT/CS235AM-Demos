using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

// MathFlashCards.v2
// This version is built on v0. It returns data from the BackActivity
// By Brian Bird, April 10, 2017

namespace MathFlashCards
{
    [Activity(Label = "MathFlashCards.v2", MainLauncher = true, Icon = "@drawable/icon")]
    public class FrontActivity : Activity
    {
        public const string EXTRA_ANSWER = "Answer";
        public const string EXTRA_RIGHT = "Right";
        const int RESULT_REQUEST = 0;  // sub-activity result request code
        MathQuiz quiz = new MathQuiz();
        int total = 0;
        int right = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // This is called when the acivity is created - which will be once, when the app is started
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Front);

            quiz.MakeRandomNumbers();

            // Show the BackActivity and send it the answer
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate {
                var back = new Intent(this, typeof(BackActivity));
                // Note: Intent is both a class and a property name, be sure you have a using statement

                back.PutExtra(EXTRA_ANSWER, quiz.Sum);
                StartActivityForResult(back, 0);
            };
        }

        protected override void OnResume()
        {
            base.OnResume();

            quiz.MakeRandomNumbers();

            // Display the two numbers to add
            TextView firstNumberTextView = FindViewById<TextView>(Resource.Id.firstNumberTextView);
            firstNumberTextView.Text = quiz.FirstNumber.ToString();

            var secondNumberTextView = FindViewById<TextView>(Resource.Id.secondNumberTextView);
            secondNumberTextView.Text = quiz.SecondNumber.ToString();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == RESULT_REQUEST)
            {
                if (resultCode == Result.Ok)
                {
                    total++;
                    if(data.GetBooleanExtra(EXTRA_RIGHT, false))
                    {
                        right++;
                    }
                    var scoreTextView = FindViewById<TextView>(Resource.Id.scoreTextView);
                    scoreTextView.Text = string.Format("{0} right out of {1}", right, total);
                }
            }
        }
    }
}

