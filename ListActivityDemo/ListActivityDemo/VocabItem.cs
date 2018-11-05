using System;
namespace ListActivityDemo
{
    public class VocabItem
	{
		public string Spanish { get; set; }
		public string English { get; set; }

		public VocabItem(string s, string e)
		{
			Spanish = s;
			English = e;
		}

		public override string ToString()
		{
			return Spanish;
		}
	}
}
