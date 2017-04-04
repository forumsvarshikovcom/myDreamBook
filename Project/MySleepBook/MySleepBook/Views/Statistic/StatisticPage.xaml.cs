using MySleepBook.Infrastructure.Constants;
using MySleepBook.ViewModels.Statistics;
using Xamarin.Forms;
using XamForms.Controls;

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

            CustomCalendar.BackgroundColor = CustomColors.Green;
            CustomCalendar.BorderColor = CustomColors.LightGreen;
            CustomCalendar.BorderWidth = 1;
            CustomCalendar.DatesBackgroundColor = CustomColors.Green;
            CustomCalendar.DatesTextColor = CustomColors.Yellow;
            CustomCalendar.DatesBackgroundColorOutsideMonth = CustomColors.LightGreen;
            CustomCalendar.DatesTextColorOutsideMonth = Color.FromHex("#f3e4cb");
            CustomCalendar.NumberOfWeekTextColor = CustomColors.Yellow;
            CustomCalendar.OuterBorderWidth = 1;
            CustomCalendar.SelectedTextColor = CustomColors.Yellow;
            CustomCalendar.SelectedBorderColor = CustomColors.Yellow;
            CustomCalendar.SelectedBorderWidth = 2;
            CustomCalendar.Padding = new Thickness(10);
        }
    }
}
