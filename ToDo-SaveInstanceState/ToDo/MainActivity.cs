using Android.App;
using Android.Widget;
using Android.OS;

namespace ToDo
{
	[Activity (Label = "ToDo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		TaskMaster taskMaster;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Main);

			taskMaster = new TaskMaster ();

			var taskTextView = FindViewById<TextView> (Resource.Id.taskTextView);
			taskTextView.Text = taskMaster.GetTaskDescriptions ();

			Button enterButton = FindViewById<Button> (Resource.Id.enterButton);
			
			enterButton.Click += delegate {
				// TODO write code to add task
			};
		}
	}
}


