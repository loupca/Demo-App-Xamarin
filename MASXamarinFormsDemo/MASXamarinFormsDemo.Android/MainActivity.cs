using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using MASXamarinFormsDemo.Exceptions;

namespace MASXamarinFormsDemo.Droid
{
    // Note that splashscreen style is used... this tricks the app into always showing the splash whenever it's loaded. We swap it to the normal theme when it loads.
    [Activity(Label = "MASXamarinFormsDemo", Icon = "@drawable/icon", Theme = "@style/splashscreen", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            // Swap back to the normal app theme.
            Window.RequestFeature(WindowFeatures.ActionBar);
            SetTheme(Resource.Style.MainTheme);

            // Finish the Android activity startup process.
            base.OnCreate(bundle);

            // Hand control over to Xamarin.Forms.
            try
            {
                global::Xamarin.Forms.Forms.Init(this, bundle);
                App.IdeaService = new MASPoweredIdeaServiceAndroid(this);
            }
            catch (CouldNotStartMasException ex)
            {
                // Show an alert if we couldn't start MAS.                
                var alert = new AlertDialog.Builder(this);
                alert.SetTitle("Error");
                alert.SetMessage("MAS could not be started. Is it configured properly?");
                var dialog = alert.Create();
                dialog.Show();
                return;
            }

            LoadApplication(new App());

        }
    }
}

