using Android.App;
using Android.Widget;
using Android.OS;
using System.Xml.Serialization;
using System.IO;

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

			if (savedInstanceState == null) {
				taskMaster = new TaskMaster ();
			}
			else {
				XmlSerializer x = new XmlSerializer(typeof(TaskMaster));
				taskMaster = (TaskMaster)x.Deserialize(
					new StringReader(savedInstanceState.GetString("Tasks")));
			}

			var taskTextView = FindViewById<TextView> (Resource.Id.taskTextView);
			taskTextView.Text = taskMaster.GetTaskDescriptions ();

			Button enterButton = FindViewById<Button> (Resource.Id.enterButton);
			var taskEditText = FindViewById<EditText>(Resource.Id.taskEditText);
			enterButton.Click += delegate {
				taskMaster.AddTask(taskEditText.Text);
				taskTextView.Text = taskMaster.GetTaskDescriptions ();
				taskEditText.Text = "";
			};
		}

		protected override void OnSaveInstanceState (Bundle outState)
		{
			StringWriter writer = new StringWriter ();

			XmlSerializer taskMasterSerializer = new XmlSerializer(typeof(TaskMaster));
			taskMasterSerializer.Serialize(writer, taskMaster);

			string serialTasks = writer.ToString ();
			outState.PutString ("Tasks", serialTasks );
			base.OnSaveInstanceState (outState);
		}
	}
}


