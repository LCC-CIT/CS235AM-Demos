using System;
using System.Collections.Generic;

namespace ToDo
{
	public class Task
	{
		public string Description { get; set;}
		public int Priority { get; set;}
		public DateTime DueDate {get; set;}
	}


	public class TaskMaster
	{
		private List<Task> tasks = new List<Task>();

		public List<Task> Tasks {get { return tasks; } }

		// default constructor
		public TaskMaster()
		{
			// nothing to do
		}

		// Temporary, for testing. will be called if you pass any string
		public TaskMaster(string dummy)
		{
			tasks.Add(new Task() {Description = "My first horrible task"});
			tasks.Add(new Task() {Description = "A not so bad task"});
			tasks.Add(new Task() {Description = "A fun and easy task"});
		}

		public string GetTaskDescriptions()
		{
			string descriptions = "";
			foreach (Task t in tasks) {
				descriptions += t.Description + "\n\r";
			}

			return descriptions;
		}

		// TODO Add more than just a description
		public void AddTask(string description)
		{
			var task = new Task () { Description = description };
			tasks.Add (task);
		}

	}
}

