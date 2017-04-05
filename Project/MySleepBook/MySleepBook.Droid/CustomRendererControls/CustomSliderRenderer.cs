using Android.Graphics;
using MySleepBook.CustomControls.StatisticCalendar;
using MySleepBook.Droid.CustomRendererControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSlider), typeof(CustomSliderRenderer))]
namespace MySleepBook.Droid.CustomRendererControls
{
    public class CustomSliderRenderer:SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            CustomSlider customSlider = (CustomSlider)this.Element;

            if (null != Control)
            {
                Control.ProgressDrawable.SetColorFilter(customSlider.LineColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                Control.Thumb.SetColorFilter(customSlider.LineColor.ToAndroid(), PorterDuff.Mode.SrcIn);
            }
        }
    }
}