using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Fragment_CustomView_Venio {
	[Activity(Label = "Fragment_CustomView_Venio", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity {

		List<CustomerModel> customerModel;
		ListView listviewCustomer;




		List<DemoActivityModel> demoActivityModel;
		ListView listviewActivity;

		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			//listview Customer
			Init();
			//AddDataCustomer();
			//AddAdapterListViewCustomer();

			//listview Activity
			AddDataActivity();
			AddAdapterListViewActivity();
		}

		void Init() {
			//listview Customer
			customerModel = new List<CustomerModel>();
			listviewCustomer = FindViewById<ListView>(Resource.Id.lvCustomer);

			//listview Activity
			demoActivityModel = new List<DemoActivityModel>();
			listviewActivity = FindViewById<ListView>(Resource.Id.lvActivity);
		}



		void AddAdapterListViewActivity() {
			CustomListViewSearchActivity customListViewSearchActivityAdapter = new CustomListViewSearchActivity(this, demoActivityModel); //listProductModel
			listviewActivity.Adapter = customListViewSearchActivityAdapter;
		}

		void AddDataActivity() {
			demoActivityModel.Add(new DemoActivityModel {
				ImvDisplay = "https://uploads4.wikiart.org/00115/images/pablo-picasso/iuyqtex0.jpeg!Portrait.jpeg",
				TxtTime = "10:14 น.",
				TxtCustomerN = "บจก. สยามสเตบิไลเซอร์สแอนด์เคมิกคอลส์",
				TxtCustomerStatement = "Statement Next Program",
				TxtCustomerDescription = "ติดต่อคุยงานการงานใหม่ให้กับลูกค้า ลูกค้ามีความสนใจในตัวงานของเรา"
			});


		}


		//---------------------------------------------------------------------------

		void AddAdapterListViewCustomer() {
			CustomListViewSearchCustomer employeeProfileAdapter = new CustomListViewSearchCustomer(this, customerModel); //listProductModel
			listviewCustomer.Adapter = employeeProfileAdapter;
		}

		void AddDataCustomer() {
			customerModel.Add(new CustomerModel {
				CustomerName = "บริษัท แอสเซท ไบร์ท จำกัด (มหาชน)",
				CustomerContact = "คุณ สุชัย มาชาบุญ",
				CustomerAddress = "1 ถนน ราชดำริ แขวง ลุมพนี เข ปทุมวัน กรุงเทพมหานคร 1033"
			});

			customerModel.Add(new CustomerModel {
				CustomerName = "บริษัท เอเชีย เอวิเอชั่น จำกัด(มหาชน",
				CustomerContact = "คุณ สมหมาย สังเกิด",
				CustomerAddress = "222 ท่าอากาศยานดอนเมืองอาคารส่วนกลางชั้น 3 ถ.วิภาวดีรังสิต แขวงสนามบิน แขวงสนามบิน เขตดอนเมือง กทม. 10140"
			});
		}
	}
}
