using Android.App;
using Android.Graphics.Drawables;
using MySleepBook.Droid.CustomRendererControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]
namespace MySleepBook.Droid.CustomRendererControls
{
    public class CustomNavigationRenderer: NavigationRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            RemoveAppIconFromActionBar();
        }
        void RemoveAppIconFromActionBar()
        {
            var actionBar = ((Activity)Context).ActionBar;

            actionBar.SetIcon(new ColorDrawable(Color.Transparent.ToAndroid()));
        }
    }
}