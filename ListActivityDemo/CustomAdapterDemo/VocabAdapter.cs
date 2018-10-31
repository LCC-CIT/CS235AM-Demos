using Android.App;
using Android.Views;
using Android.Widget;

namespace CustomAdapterDemo
{
	public class VocabAdapter : BaseAdapter<VocabItem>
	{
		VocabItem[] items;
		Activity context;

		// The constructor takes a reference to the host Activity and a data array
		public VocabAdapter(Activity c, VocabItem[] i) : base()
		{
			items = i;
			context = c;
		}

		// Returns the row id, which is the same as the items array index
		public override long GetItemId(int position)
		{
			return position;
		}

		// position indexes the array to get the object in that array element
		public override VocabItem this[int position]
		{
			get { return items[position]; }
		}

		// Returns the count of elements in the array
		public override int Count
		{
			get { return items.Length; }
		}

		// Used by the ListView to recycyle the View objects used for each row as
		// the List is scrolled.
		// ConvertView is the one that just got scrolled off the ListView
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (view == null)
				view = context.LayoutInflater.Inflate(
					Android.Resource.Layout.TwoLineListItem,
					null);
			view.FindViewById<TextView>(Android.Resource.Id.Text1).Text
				= items[position].English;
			view.FindViewById<TextView>(Android.Resource.Id.Text2).Text
				= items[position].Spanish;
			return view;
		}
	}
}
