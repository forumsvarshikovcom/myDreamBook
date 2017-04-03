﻿using System.Linq;
using Windows.UI;
using Windows.UI.Xaml.Media;
using MySleepBook.CustomControls.Chart;
using MySleepBook.UWP.CustomRendererControls;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Chart), typeof(ChartRenderer))]
namespace MySleepBook.UWP.CustomRendererControls
{
    /// <summary>
	/// Class ChartRenderer.
	/// </summary>
	public class ChartRenderer : ViewRenderer<Chart, ChartSurface>
	{
		/// <summary>
		/// Called when [element changed].
		/// </summary>
		/// <param name="e">The e.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Chart> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null || this.Element == null)
				return;


			// Use color specified at DataPoints if it is a Pie Chart
			Color[] colors;
			Series pieSeries = Element.Series.FirstOrDefault(s => s.Type == ChartType.Pie);
			if (pieSeries != null)
			{
				colors = new Color[pieSeries.Points.Count];
				for (int i = 0; i < pieSeries.Points.Count; i++)
				{
					colors[i] = Color.FromArgb(
					   (byte)(pieSeries.Points[i].Color.A * 255),
					   (byte)(pieSeries.Points[i].Color.R * 255),
					   (byte)(pieSeries.Points[i].Color.G * 255),
					   (byte)(pieSeries.Points[i].Color.B * 255));
				}
			}
			else
			{
				colors = new Color[Element.Series.Count];
				for (int i = 0; i < Element.Series.Count; i++)
				{
					colors[i] = Color.FromArgb(
					(byte)(Element.Series[i].Color.A * 255),
					(byte)(Element.Series[i].Color.R * 255),
					(byte)(Element.Series[i].Color.G * 255),
					(byte)(Element.Series[i].Color.B * 255));
				}
			}

			Color color = Color.FromArgb(
					(byte)(Element.Color.A * 255),
					(byte)(Element.Color.R * 255),
					(byte)(Element.Color.G * 255),
					(byte)(Element.Color.B * 255));

			ChartSurface surfaceView = new ChartSurface(Element, color, colors);
			SetNativeControl(surfaceView);
		}

		/// <summary>
		/// Handles the <see cref="E:ElementPropertyChanged" /> event.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			// TODO: To be improved
			base.OnElementPropertyChanged(sender, e);
			if (this.Element == null || this.Control == null)
				return;

			if (e.PropertyName == Chart.ColorProperty.PropertyName)
			{
				Control.Brush = new SolidColorBrush(Color.FromArgb(
					(byte)(Element.Color.A * 255),
					(byte)(Element.Color.R * 255),
					(byte)(Element.Color.G * 255),
					(byte)(Element.Color.B * 255)));
				Control.Redraw();
			}
			else if (e.PropertyName == Chart.GridProperty.PropertyName)
			{
				Control.Chart.Grid = Element.Grid;
				Control.Redraw();
			}
			else if (e.PropertyName == Chart.HeightProperty.PropertyName)
			{
				Control.Chart.HeightRequest = Element.HeightRequest;
				Control.Redraw();
			}
			else if (e.PropertyName == Chart.SeriesProperty.PropertyName)
			{
				Control.Chart.Series = Element.Series;
				Control.Redraw();
			}
			else if (e.PropertyName == Chart.SpacingProperty.PropertyName)
			{
				Control.Chart.Spacing = Element.Spacing;
				Control.Redraw();
			}
			else if (e.PropertyName == Chart.WidthProperty.PropertyName)
			{
				Control.Chart.WidthRequest = Element.WidthRequest;
				Control.Redraw();
			}
			else if (e.PropertyName == Chart.DataSourceProperty.PropertyName)
			{
				Control.Chart.DataSource = Element.DataSource;
				Control.Redraw();
			}
		}
	}
}
