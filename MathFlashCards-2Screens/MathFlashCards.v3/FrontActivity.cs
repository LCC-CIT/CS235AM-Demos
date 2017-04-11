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
        MathQuiz quiz = new MathQuiz();

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
                StartActivity(back);
            };
        }


        // This is called every time the back button at the bottom of the screen is tapped,
        // and it is called after onCreate the first time the activity is launched
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
    }
}

