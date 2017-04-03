using MySleepBook.CustomControls;
using MySleepBook.Droid.CustomRendererControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryWithBorder), typeof(EntryWithBorderRenderer))]
namespace MySleepBook.Droid.CustomRendererControls
{
    public class EntryWithBorderRenderer: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null) return;

            this.Control.Background = this.Resources.GetDrawable(Resource.Layout.EntryWithBorder);
        }
    }
}