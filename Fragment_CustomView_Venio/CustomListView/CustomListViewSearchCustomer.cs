using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;


namespace Fragment_CustomView_Venio {
	public class CustomListViewSearchCustomer : BaseAdapter {

		Activity activity;
		List<CustomerModel> customerList;

		public CustomListViewSearchCustomer(Activity activity, List<CustomerModel> customerList) {
			this.activity = activity;
			this.customerList = customerList;
		}

		public override int Count {
			get {
				return customerList.Count;
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
				view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.Recyclerview_Search_Customer, parent, false);
				viewholder = new ViewHolder();

				viewholder.txtCustomerName = view.FindViewById<TextView>(Resource.Id.txtCustomerName);
				viewholder.txtCustomerContact = view.FindViewById<TextView>(Resource.Id.txtCustomerContact);
				viewholder.txtCustomerAddress = view.FindViewById<TextView>(Resource.Id.txtCustomerAddress);

				view.Tag = viewholder;

			} else {
				viewholder = (ViewHolder)view.Tag;
			}
			viewholder.txtCustomerName.Text = customerList[position].CustomerName;
			viewholder.txtCustomerContact.Text = customerList[position].CustomerContact;
			viewholder.txtCustomerAddress.Text = customerList[position].CustomerAddress;

			return view;
		}

		private class ViewHolder : Java.Lang.Object {
			//public ImageView imvShow;
			public TextView txtCustomerName;
			public TextView txtCustomerContact;
			public TextView txtCustomerAddress;
		}


	}
}
