using System.ComponentModel;
using Android.Graphics.Drawables;
using MySleepBook.CustomControls;
using MySleepBook.Droid.CustomRendererControls;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace MySleepBook.Droid.CustomRendererControls
{
	public class CustomFrameRenderer : VisualElementRenderer<CustomFrame>
	{
		private GradientDrawable _normal, _pressed;

		protected override void OnElementChanged(ElementChangedEventArgs<CustomFrame> e)
		{

			CustomFrame customFram = e.NewElement as CustomFrame;
			// Create a drawable for the button's normal state
			_normal = new Android.Graphics.Drawables.GradientDrawable();
			_normal.SetColor(customFram.InlineColor.ToAndroid());
			_normal.SetStroke(customFram.BorderWidth, customFram.OutlineColor.ToAndroid());
			_normal.SetCornerRadius(customFram.BorderRadius);
			SetBackgroundDrawable(_normal);
			//SetBackgroundColor(customFram.BackgroundColor.ToAndroid());
			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
		}
	}
}