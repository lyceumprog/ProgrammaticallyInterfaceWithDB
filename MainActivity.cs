using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ProgrammaticallyInterface
{
	[Activity (Label = "ProgrammaticallyInterface", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it

			RelativeLayout mainLayout = 
				FindViewById<RelativeLayout> 
				(Resource.Id.relativeLayout1);

			Button b1 = new Button (this);
			b1.Text = "1";
			b1.Id = 1;

			b1.Click += delegate {
				StartActivity(typeof(BookshelfActivity));
			};

			Button b2 = new Button (this);
			b2.Text = "2";
			b2.Id = 2;

			RelativeLayout.LayoutParams b2Settings = 
				new RelativeLayout.LayoutParams 
				(ViewGroup.LayoutParams.WrapContent, 40);
			b2Settings.AddRule (LayoutRules.Below, b1.Id);
			b2Settings.AddRule (LayoutRules.RightOf, b1.Id);
			b2.LayoutParameters = b2Settings;

			Button b3 = new Button (this);
			b3.Text = "3";
			b3.Id = 3;

			RelativeLayout.LayoutParams b3Settings = 
				new RelativeLayout.LayoutParams 
				(ViewGroup.LayoutParams.WrapContent, 40);
			b3Settings.AddRule (LayoutRules.RightOf, b2.Id);
			b3.LayoutParameters = b3Settings;

			Button b4 = new Button (this);
			b4.Text = "4";
			b4.Id = 4;

			RelativeLayout.LayoutParams b4Settings = new RelativeLayout.LayoutParams (ViewGroup.LayoutParams.WrapContent, 40);
			b4Settings.AddRule (LayoutRules.RightOf, b3.Id);
			b4Settings.AddRule (LayoutRules.Below, b3.Id);
			b4.LayoutParameters = b4Settings;

			mainLayout.AddView (b1);
			mainLayout.AddView (b2);
			mainLayout.AddView (b3);
			mainLayout.AddView (b4);
		}
	}
}


