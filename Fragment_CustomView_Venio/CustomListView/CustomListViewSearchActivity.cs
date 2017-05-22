using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using ListViewTrain;
using Square.Picasso;

namespace Fragment_CustomView_Venio {
	public class CustomListViewSearchActivity : BaseAdapter {
		Activity activity;
		List<DemoActivityModel> demoActivityList;

		public CustomListViewSearchActivity(Activity activity, List<DemoActivityModel> demoActivityList) {
			this.activity = activity;
			this.demoActivityList = demoActivityList;
		}

		public override int Count {
			get {
				return demoActivityList.Count;
			}
		}

		public override Java.Lang.Object GetItem(int position) {
			return position;
		}

		public override long GetItemId(int position) {
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent) {
			View view = convertView;
			ViewHolder viewholder;

			if (view == null) {
				view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.Recyclerview_Search_Activity, parent, false);
				viewholder = new ViewHolder();

				viewholder.imvDisplay = view.FindViewById<ImageView>(Resource.Id.imvDisplay);
				viewholder.txtTime = view.FindViewById<TextView>(Resource.Id.txtTime);

				viewholder.txtCustomerN = view.FindViewById<TextView>(Resource.Id.txtCustomerN);
				viewholder.txtCustomerStatement = view.FindViewById<TextView>(Resource.Id.txtCustomerStatement);
				viewholder.txtCustomerDescription = view.FindViewById<TextView>(Resource.Id.txtCustomerDescription);

				view.Tag = viewholder;
			} else {
				viewholder = (ViewHolder)view.Tag;
			}

			//image
			//viewholder.imvDisplay.Text = demoActivityList[position].CustomerName;
			Picasso.With(activity)
			   .Load("http://i.imgur.com/DvpvklR.png")
			   .Transform(new CircleTransform())
			   .Into(viewholder.imvDisplay);
			viewholder.txtTime.Text = demoActivityList[position].TxtTime;

			viewholder.txtCustomerN.Text = demoActivityList[position].TxtCustomerN;
			viewholder.txtCustomerStatement.Text = demoActivityList[position].TxtCustomerStatement;
			viewholder.txtCustomerDescription.Text = demoActivityList[position].TxtCustomerDescription;

			return view;
		}

		private class ViewHolder : Java.Lang.Object {
			public ImageView imvDisplay;
			public TextView txtTime;

			public TextView txtCustomerN;
			public TextView txtCustomerStatement;
			public TextView txtCustomerDescription;
		}
	}
}
