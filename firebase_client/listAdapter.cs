using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace firebase_client
{
    internal class ListAdapter : BaseAdapter<dbItem> 
    {
        private List<dbItem> values;
        private Context context;
        private int count, changedPos;
        public ListAdapter(Context context, List<dbItem> values)
        {
            this.context = context;
            this.values = values;
            this.count = values.Count;
        }

        public List<dbItem> GetList()
        {
            return this.values;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override int Count
        {
            get { return count; }
        }

        public override dbItem this[int position] => throw new System.NotImplementedException();

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            Android.Views.LayoutInflater layoutInflater = ((MainActivity)context).LayoutInflater;
            Android.Views.View view = layoutInflater.Inflate(Resource.Layout.list_item, parent, false);
            TextView tv = view.FindViewById<TextView>(Resource.Id.tv);
            if (position < values.Count)
            {
                if (values[position] != null)
                    tv.Text = values[position].GetValue();
                if (position == changedPos)
                    tv.SetTextColor(Color.Red);
            }
            return view;
        }
        public void SetCangedPos(int position)
        {
            changedPos = position;
        }

    }
}