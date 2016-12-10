using Android.App;
using Android.Widget;
using Android.OS;

namespace Facebook.Yoga.Android.Test
{
	[Activity(Label = "Facebook.Yoga.Android.Test", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);


			var view = new TextView(this);
			view.Text = "Hello";
			SetContentView(view);
		}
	}
}

