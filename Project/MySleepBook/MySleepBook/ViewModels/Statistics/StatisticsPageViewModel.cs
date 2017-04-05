using System;
using MySleepBook.Views.PopUps;
using System.Windows.Input;
using MySleepBook.CustomControls.StatisticCalendar;
using MySleepBook.Infrastructure.Resourses;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
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
        public StatisticCalendarModel CalendarModel { get; set; }

        public StatisticsPageViewModel()
        {
            CalendarModel = new StatisticCalendarModel
            {
                SelectedDateTime = DateTime.Now,
                DateSelectAction = () =>
                {
                    var page = new Statistic_Add_Edit_PopUp();
                    PopupNavigation.PushAsync(page, true);
                }
            };
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
