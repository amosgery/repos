using Android.Views;

namespace listview.net
{
    public class ToyAdapter : BaseAdapter<Toy>
    {
        Android.Content.Context context;
        List<Toy> objects;

        public ToyAdapter(Android.Content.Context context, System.Collections.Generic.List<Toy> objects)
        {
            this.context = context;
            this.objects = objects;
        }

        public override int Count
        {
            get { return this.objects.Count; }
        }

        public override Toy this[int position]
        {
            get { return this.objects[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Android.Views.LayoutInflater layoutInflater = ((MainActivity)context).LayoutInflater;
            Android.Views.View view = layoutInflater.Inflate(Resource.Layout.list_item, parent, false);
            TextView tvTitle = view.FindViewById<TextView>(Resource.Id.tvTitle);
            TextView tvSubTitle = view.FindViewById<TextView>(Resource.Id.tvSubTitle);
            TextView tvPrice = view.FindViewById<TextView>(Resource.Id.tvPrice);
            ImageView ivProduct = view.FindViewById<ImageView>(Resource.Id.ivProduct);
            Toy temp = objects[position];
            if (temp != null)
            {
                tvPrice.Text = "" + temp.Price;
                tvTitle.Text = temp.Title;
                tvSubTitle.Text = temp.Subtitle;
            }
            return view;
        }

        public override long GetItemId(int position)
        {
            return objects[position].Id;
        }
    }
}
