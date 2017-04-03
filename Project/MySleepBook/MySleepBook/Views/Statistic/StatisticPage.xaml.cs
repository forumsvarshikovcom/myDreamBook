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
        }
    }
}
