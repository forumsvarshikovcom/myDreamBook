using System;
using System.Threading.Tasks;
using MySleepBook.CustomControls.Chart;
using MySleepBook.CustomControls.StatisticCalendar;
using MySleepBook.ViewModels.Statistics;
using Xamarin.Forms;

namespace MySleepBook.Views.Statistic
{
    public partial class StatisticPage : ContentPage
    {
        private StatisticsPageViewModel _viewModel;
        public StatisticPage()
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(StatisticsPageViewModel), "statisticsPageViewModel") as StatisticsPageViewModel;
            BindingContext = _viewModel;
            _viewModel.Navigation = Navigation;

            var serias = _viewModel.GetSerias();

            Series firstBarSeries = new Series
            {
                Color = Color.Red,
                Type = ChartType.Line,
                Points = serias.BadDreamPoints
            };
            Series secondBarSeries = new Series
            {
                Color = Color.Green,
                Type = ChartType.Line,
                Points = serias.GoodDreamPoints
            };
            Series freeckBarSerias = new Series
            {
                Color = Color.Transparent,
                Type = ChartType.Line,
                //Points = serias.FreecPoints
            };
            foreach (var seriasFreecPoint in serias.FreecPoints)
            {
                freeckBarSerias.Points.Add(seriasFreecPoint);
            }
            Chart chart = new Chart()
            {
                Color = Color.White,
                WidthRequest = 400,
                HeightRequest = 300
            };
            chart.Series.Add(firstBarSeries);
            chart.Series.Add(secondBarSeries);
            chart.Series.Add(freeckBarSerias);

            ChartWrapper.Children.Add(chart);
            Task.Run(async () =>
            {
                await Task.Delay(Device.OS == TargetPlatform.Android ? 260 : 100);
                Device.BeginInvokeOnMainThread(() =>
                {
                    var calendar = new StatisticCalendar(_viewModel.CalendarModel);
                    _viewModel.GetStatisticPerMounth(DateTime.Now);
                    CalendarWrapper.Children.Add(calendar);
                    calendar.FadeTo(1, 500);
                });
            });
        }
    }
}
