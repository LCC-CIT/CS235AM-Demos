using Android.App;
using Android.Views;
using Android.Widget;

namespace CustomAdapterDemo
{
	public class VocabAdapter : BaseAdapter<VocabItem>
	{
		VocabItem[] items;
		Activity context;

		public VocabAdapter(Activity c, VocabItem[] i) : base()
		{
			items = i;
			context = c;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override VocabItem this[int position]
		{
			get { return items[position]; }
		}

		public override int Count
		{
			get { return items.Length; }
		}

		public override View GetView(int position, View convertView,ViewGroup parent)
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
