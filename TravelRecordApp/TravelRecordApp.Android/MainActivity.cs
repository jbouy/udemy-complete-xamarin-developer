using System.IO;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Environment = System.Environment;
using Platform = Xamarin.Essentials.Platform;

namespace TravelRecordApp.Droid
{
    [Activity(Label = "TravelRecordApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            var dbName = "travel_db.sqlite";
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var fullPath = Path.Combine(folderPath, dbName);

            LoadApplication(new App(fullPath));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}