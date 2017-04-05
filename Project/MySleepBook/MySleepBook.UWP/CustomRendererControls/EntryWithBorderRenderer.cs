using Windows.UI;
using Windows.UI.Xaml.Media;
using MySleepBook.CustomControls;
using MySleepBook.UWP.CustomRendererControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Thickness = Windows.UI.Xaml.Thickness;

[assembly: ExportRenderer(typeof(EntryWithBorder), typeof(EntryWithBorderRenderer))]
namespace MySleepBook.UWP.CustomRendererControls
{
    public class EntryWithBorderRenderer:EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = new SolidColorBrush(Colors.Transparent);
                Control.BorderThickness = new Thickness(1);
            }
        }
    }
}