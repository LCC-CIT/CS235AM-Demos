namespace CustomAdapterDemo
{
	public class VocabItem
	{
		public string Spanish { get; set; }
		public string English { get; set; }
		public string PartOfSpeech { get; set; }

		public VocabItem(string s, string e)
		{
			Spanish = s;
			English = e;
		}

		public VocabItem(string s, string e, string pos)
		{
			Spanish = s;
			English = e;
			PartOfSpeech = pos;
		}

        // More or less arbitrary choice to just use the Spanish word
		public override string ToString ()
		{
			return Spanish;
		}
	}
}


