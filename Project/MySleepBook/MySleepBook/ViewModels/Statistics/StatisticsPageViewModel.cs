using System;
using System.Linq;
using MySleepBook.Views.PopUps;
using System.Windows.Input;
using MySleepBook.CustomControls.StatisticCalendar;
using MySleepBook.DataManagers.LocalDbManager.Domain;
using MySleepBook.Infrastructure.Constants;
using MySleepBook.Infrastructure.Models;
using MySleepBook.Infrastructure.Resourses;
using MySleepBook.Services.Interfaces;
using MySleepBook.ViewModels.PopUps;
using Rg.Plugins.Popup.Services;
using XamForms.Controls;

namespace MySleepBook.ViewModels.Statistics
{
    public class StatisticsPageViewModel : BaseViewModel
    {
        public ICommand ShowAddEditStatisticPopUp { get; set; }
        private int _chartTypeSelectedIndex;
        private bool _chartIsVisible;
        private string _noStatisticText;
        public StatisticCalendarModel CalendarModel { get; set; }
        //public Action 

        private IDreamCalendarService _dreamCalendarService;

        public StatisticsPageViewModel(IDreamCalendarService dreamCalendarService)
        {
            _dreamCalendarService = dreamCalendarService;
            CalendarModel = new StatisticCalendarModel
            {
                SelectedDateTime = DateTime.Now,
                MounthChangedAction = args => { GetStatisticPerMounth(args);},
                DateSelectAction = DateSelectionProcess
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

        public void GetStatisticPerMounth(DateTime currentCalendarDate)
        {
            CalendarModel.FilledDays =
                _dreamCalendarService.GetStatisticPerMounth(currentCalendarDate).Select(statistic => new SpecialDate(DateTime.Parse(statistic.Date))
                {
                    Selectable = true,
                    BackgroundColor = CustomColors.Green,
                    TextColor = CustomColors.Yellow
                }).ToList();

            CalendarModel.RedrawSpecialDatesAction.Invoke();
            ChartIsVisible = CalendarModel.FilledDays.Any();
        }

        public SeriasForChart GetSerias()
        {
            return _dreamCalendarService.GetSeriasForChart(_chartTypeSelectedIndex == 0, CalendarModel.SelectedDateTime);
        }
        #region privateMethods

        private void DateSelectionProcess()
        {
            var storedStatistic = _dreamCalendarService.GetStatisticPerDay(this.CalendarModel.SelectedDateTime);

            var statisticViewModel = App.Container.Resolve(typeof(Statistic_Add_Edit_PopUpViewModel), "statistic_Add_Edit_PopUpViewModel") as Statistic_Add_Edit_PopUpViewModel;

            statisticViewModel.BadSleepLineValue = storedStatistic?.BadDreamValue ?? 2.5;
            statisticViewModel.GoodSleepLineValue = storedStatistic?.GoodDreamValue ?? 2.5;
            statisticViewModel.SaveAction = () => { SaveCalendarStatistic(storedStatistic, statisticViewModel); };

            var page = new Statistic_Add_Edit_PopUp(statisticViewModel);
            PopupNavigation.PushAsync(page, false);
        }

        private void SaveCalendarStatistic(DreamCalendar storedStatistic, Statistic_Add_Edit_PopUpViewModel statisticViewModel)
        {
            if (storedStatistic != null)
            {
                storedStatistic.BadDreamValue = statisticViewModel.BadSleepLineValue;
                storedStatistic.GoodDreamValue = statisticViewModel.GoodSleepLineValue;
                _dreamCalendarService.UpdateStatisticPerDay(storedStatistic);
            }
            else
            {
                _dreamCalendarService.CreateStatisticPerDay(new DreamCalendar
                {
                    Date = this.CalendarModel.SelectedDateTime.ToString("d"),
                    GoodDreamValue = statisticViewModel.GoodSleepLineValue,
                    BadDreamValue = statisticViewModel.BadSleepLineValue
                });
                CalendarModel.FilledDays.Add(new SpecialDate(DateTime.Now)
                {
                    Selectable = true,
                    BackgroundColor = CustomColors.Green,
                    TextColor = CustomColors.Yellow
                });
                CalendarModel.RedrawSpecialDatesAction.Invoke();
            }
        }
        #endregion
    }
}
