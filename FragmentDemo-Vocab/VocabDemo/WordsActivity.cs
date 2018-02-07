using Android.App;
using Android.Content;
using Android.OS;

namespace VocabPractice
{
	[Activity(Label = "Words")]			
	public class WordsActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			var wordsFrag = new WordsFragment () { Arguments = Intent.Extras };

			var fragmentTransaction = FragmentManager.BeginTransaction();          
			fragmentTransaction.Add(Android.Resource.Id.Content, wordsFrag);
			fragmentTransaction.Commit();
		}
	}
}

