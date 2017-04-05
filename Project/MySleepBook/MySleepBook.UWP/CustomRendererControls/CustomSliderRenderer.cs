using Windows.UI.Xaml.Media;
using MySleepBook.CustomControls.StatisticCalendar;
using MySleepBook.UWP.CustomRendererControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomSlider), typeof(CustomSliderRenderer))]
namespace MySleepBook.UWP.CustomRendererControls
{
    public class CustomSliderRenderer : SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var _control = e.NewElement as CustomSlider;
                Control.Foreground = new SolidColorBrush(ToMediaColor(_control.LineColor));
            }
        }
        public static Windows.UI.Color ToMediaColor(Xamarin.Forms.Color color)
        {
            return Windows.UI.Color.FromArgb(((byte)(color.A * 255)), (byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255));
        }
    }
}
