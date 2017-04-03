using Windows.UI;
using Windows.UI.Xaml.Media;
using MobileClient.UWP.CustomRendererControls;
using MySleepBook.CustomControls;
using Xamarin.Forms.Platform.UWP;
using Thickness = Windows.UI.Xaml.Thickness;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(EntryWithBorder), typeof(EntryWithBorderRenderer))]
namespace MobileClient.UWP.CustomRendererControls
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