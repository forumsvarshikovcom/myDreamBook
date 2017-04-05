using Xamarin.Forms;

namespace MySleepBook.CustomControls.StatisticCalendar
{
    public class CustomSlider:Slider
    {
        public readonly static BindableProperty LineColorProperty = BindableProperty.Create("LineColor", typeof(Color), typeof(CustomSlider), Color.Default, BindingMode.OneWay, null, null, null, null, null);
        public Color LineColor
        {
            get
            {
                return (Color)base.GetValue(CustomSlider.LineColorProperty);
            }
            set
            {
                base.SetValue(CustomSlider.LineColorProperty, value);
            }
        }
    }
}
