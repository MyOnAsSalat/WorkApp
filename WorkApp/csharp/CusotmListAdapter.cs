using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace WorkApp.csharp
{
    public class CusotmListAdapter : BaseAdapter<User>
    {
        readonly Activity Context;
        readonly List<User> List;

        public CusotmListAdapter(Activity _context, List<User> _list)
        {
            Context = _context;
            List = _list;
        }

        public override int Count => List.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override User this[int index] => List[index];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            View view = convertView ?? Context.LayoutInflater.Inflate(Resource.Layout.list_item, parent, false);

            User item = this[position];
            view.FindViewById<TextView>(Resource.Id.user_id_textview).Text = item.userId.ToString();
            view.FindViewById<TextView>(Resource.Id.id_textview).Text = item.id.ToString();
            view.FindViewById<TextView>(Resource.Id.title_textview).Text = item.title;
            view.FindViewById<TextView>(Resource.Id.body_textview).Text = item.body;
            return view;
        }
    }
}