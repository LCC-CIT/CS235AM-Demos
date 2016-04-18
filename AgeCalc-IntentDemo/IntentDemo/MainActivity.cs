using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace IntentDemo
{
	[Activity (Label = "IntentDemo", MainLauncher = true)]
	public class MainActivity : Activity
	{
		public const string EXTRA_BIRTHDAY = "Birthday";
		public const string EXTRA_NAME = "Name";
		public const string EXTRA_AGE = "Age";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			EditText etName = FindViewById<EditText> (Resource.Id.etName);
			// EditText etBirthday = FindViewById<EditText> (Resource.Id.etBirthday);
			DatePicker dpBirthday = FindViewById<DatePicker> (Resource.Id.dpBirthday);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.btnCalc);
			
			button.Click += delegate 
			{
				string name = "";
				DateTime birthday;
				int age = 0;
				if(etName.Text == "")
				{
					Toast.MakeText(this, "Please enter everything",ToastLength.Long).Show();
				}
				else
				{
					name = etName.Text;
					//birthday = Convert.ToDateTime(etBirthday.Text);
					birthday = dpBirthday.DateTime;
					age = (int)(DateTime.Now - birthday).TotalDays / 365;
					Intent inAge = new Intent(this, typeof(AgeActivity) );
					inAge.PutExtra(EXTRA_NAME, name);
					inAge.PutExtra(EXTRA_AGE, age);
					inAge.PutExtra(EXTRA_BIRTHDAY, birthday.ToShortDateString());
					StartActivity(inAge);
				}
			};
		}
	}
}


