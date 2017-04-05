using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySleepBook.CustomControls;
using MySleepBook.CustomControls.StatisticCalendar;
using MySleepBook.Infrastructure.Constants;
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
