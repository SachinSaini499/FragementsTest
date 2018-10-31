using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Dimensions.Database.Tables;

namespace Dimensions.CustomControl
{
    class CusotmListAdapter : BaseAdapter<BarcodeDetailsTbl>
    {
        Activity context;
        List<BarcodeDetailsTbl> list;
        View view;

        public CusotmListAdapter(Activity _context, List<BarcodeDetailsTbl> _list)
            : base()
        {
            this.context = _context;
            this.list = _list;
        }

        public override int Count
        {
            get { return list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override BarcodeDetailsTbl this[int index]
        {
            get { return list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            try
            {
                view = convertView;
                if (view == null)
                    view = context.LayoutInflater.Inflate(Resource.Layout.ListItemRow, parent, false);

                BarcodeDetailsTbl item = this[position];
                view.FindViewById<TextView>(Resource.Id.tvBarcode).Text = item.Barcode;
                view.FindViewById<TextView>(Resource.Id.tvDimm).Text = item.Height + "x" + item.Width + "x" + item.Depth;
                view.FindViewById<TextView>(Resource.Id.tvDate).Text = item.Date;
                //using (var imageView = view.FindViewById<ImageView>(Resource.Id.Thumbnail))
                //{
                //  //  string url = Android.Text.Html.FromHtml(item.thumbnail).ToString();

                //    //Download and display image
                //    Koush.UrlImageViewHelper.SetUrlDrawable(imageView, url, Resource.Drawable.Placeholder);
                //}
            }
            catch(Exception ex) { }
            return view;
        }
    }
}