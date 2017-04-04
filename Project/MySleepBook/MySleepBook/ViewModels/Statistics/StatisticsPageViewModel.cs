using MySleepBook.Views.PopUps;
using System.Windows.Input;
using MySleepBook.Infrastructure.Resourses;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MySleepBook.ViewModels.Statistics
{
    public class StatisticsPageViewModel:BaseViewModel
    {
        public ICommand ShowAddEditStatisticPopUp { get; set; }
        private int _chartTypeSelectedIndex;
        private bool _chartIsVisible;
        private string _noStatisticText;

        public StatisticsPageViewModel()
        {
            ShowAddEditStatisticPopUp = new Command(() =>
            {
                var page = new Statistic_Add_Edit_PopUp();

                PopupNavigation.PushAsync(page,false);
            });
        }

        public int ChartTypeSelectedIndex
        {
            set { SetProperty(ref _chartTypeSelectedIndex, value); }
            get { return _chartTypeSelectedIndex; }
        }

        public bool ChartIsVisible
        {
            set { SetProperty(ref _chartIsVisible, value); }
            get { return _chartIsVisible; }
        }

        public string NoStatisticText
        {
            set { SetProperty(ref _noStatisticText, value); }
            get { return Common.txt_noStatistic; }
        }
    }
}
