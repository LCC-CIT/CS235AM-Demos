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

			// Create a new taskMaster, or restore a saved one
			if (savedInstanceState == null) {
				taskMaster = new TaskMaster ("testing");
			}
			else {
				// Deserialized the saved object state
				string xmlTasks = savedInstanceState.GetString("Tasks");
				XmlSerializer x = new XmlSerializer(typeof(TaskMaster));
				taskMaster = (TaskMaster)x.Deserialize(new StringReader(xmlTasks));
			}

			// Display all the tasks
			var taskTextView = FindViewById<TextView> (Resource.Id.taskTextView);
			taskTextView.Text = taskMaster.GetTaskDescriptions ();

			// Add a new task to the taskMaster list
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
			// Use this to convert a stream to a string
			StringWriter writer = new StringWriter ();

			// Serialize the public state of taskMaster to XML
			XmlSerializer taskMasterSerializer = new XmlSerializer(typeof(TaskMaster));
			taskMasterSerializer.Serialize(writer, taskMaster);

			// Save the serialized state
			string xmlTasks = writer.ToString ();
			outState.PutString ("Tasks", xmlTasks );

			base.OnSaveInstanceState (outState);
		}
	}
}


