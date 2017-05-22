using System;
using Android.Content;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Venio.Droid {
	public class CustomSearchMenu : RelativeLayout, Android.Text.ITextWatcher {
		Context context;
		private TextView txtMenuAll;
		private TextView txtMenuCustomer;
		private TextView txtMenuEmployee;
		private TextView txtMenuActivity;
		private TextView txtMenuDate;
		private EditText edtSearch;
		private ImageView imvDelete;

		public EventHandler<string> Search;
		public EventHandler Remove;
		public SearchType Type { get; set; } = SearchType.All;
		public enum SearchType { All, Customer, Employee, Activity, Date };

		public CustomSearchMenu(Context context) :
					base(context) {
			this.context = context;
			Initialize();
		}

		public CustomSearchMenu(Context context, IAttributeSet attrs) :
					base(context, attrs) {
			this.context = context;
			Initialize();
		}

		public CustomSearchMenu(Context context, IAttributeSet attrs, int defStyle) :
					base(context, attrs, defStyle) {
			this.context = context;
			Initialize();
		}

		void Initialize() {
			LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
			View view = inflater.Inflate(Resource.Layout.Customview_SearchMenu, this);

			txtMenuAll = view.FindViewById<TextView>(Resource.Id.txtMenuAll);
			txtMenuCustomer = view.FindViewById<TextView>(Resource.Id.txtMenuCustomer);
			txtMenuEmployee = view.FindViewById<TextView>(Resource.Id.txtMenuEmployee);
			txtMenuActivity = view.FindViewById<TextView>(Resource.Id.txtMenuActivity);
			txtMenuDate = view.FindViewById<TextView>(Resource.Id.txtMenuDate);
			edtSearch = view.FindViewById<EditText>(Resource.Id.edtSearch);
			imvDelete = view.FindViewById<ImageView>(Resource.Id.imvDelete);

			SetMenuActive(txtMenuAll);
			InitMenu();
			SetEvent();
		}

		private void InitMenu() {
			txtMenuAll.Click += (sender, e) => {
				this.Type = SearchType.All;
				SetMenuActive(txtMenuAll);
			};

			txtMenuCustomer.Click += (sender, e) => {
				this.Type = SearchType.Customer; ;
				SetMenuActive(txtMenuCustomer);
			};

			txtMenuEmployee.Click += (sender, e) => {
				this.Type = SearchType.Employee;
				SetMenuActive(txtMenuEmployee);
			};

			txtMenuActivity.Click += (sender, e) => {
				this.Type = SearchType.Activity;
				SetMenuActive(txtMenuActivity);
			};

			txtMenuDate.Click += (sender, e) => {
				this.Type = SearchType.Activity; ;
				SetMenuActive(txtMenuDate);
			};
		}

		private void SetMenuActive(TextView view) {
			txtMenuAll.SetTextColor(context.Resources.GetColor(Resource.Color.grey_medium));
			txtMenuCustomer.SetTextColor(context.Resources.GetColor(Resource.Color.grey_medium));
			txtMenuEmployee.SetTextColor(context.Resources.GetColor(Resource.Color.grey_medium));
			txtMenuActivity.SetTextColor(context.Resources.GetColor(Resource.Color.grey_medium));
			txtMenuDate.SetTextColor(context.Resources.GetColor(Resource.Color.grey_medium));

			view.SetTextColor(context.Resources.GetColor(Resource.Color.purple_medium));
		}



		private void SetEvent() {
			edtSearch.AddTextChangedListener(this);

			imvDelete.Click += (sender, e) => {
				edtSearch.Text = "";
				edtSearch.ClearFocus();

				if (Remove != null) {
					Remove.Invoke(sender, e);
				}
			};
		}
		public void AfterTextChanged(IEditable s) {
			if (edtSearch.Text.Length > 0) {
				imvDelete.Visibility = ViewStates.Visible;
			} else {
				imvDelete.Visibility = ViewStates.Gone;
			}

			if (Search != null && edtSearch != null) {
				Search.Invoke(s, edtSearch.Text);
			}
		}

		public void BeforeTextChanged(ICharSequence s, int start, int count, int after) {
		}

		public void OnTextChanged(ICharSequence s, int start, int before, int count) {
		}
	}
}
