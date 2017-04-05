using System;
using System.Collections.Generic;
using System.Linq;
using MySleepBook.Infrastructure.Constants;
using Xamarin.Forms;
using XamForms.Controls;

namespace MySleepBook.CustomControls.StatisticCalendar
{
    public class StatisticCalendar : Calendar
    {
        private StatisticCalendarModel _model;
        private int _currentMounth;
        public StatisticCalendar(StatisticCalendarModel model)
        {
            _model = model;
            _model.RedrawSpecialDatesAction = RedrawSpecialDates;

            BackgroundColor = CustomColors.Green;
            BorderColor = CustomColors.LightGreen;
            BorderWidth = 1;

            DatesBackgroundColor = CustomColors.Yellow;
            DatesTextColor = CustomColors.Green;

            DatesBackgroundColorOutsideMonth = CustomColors.LightGreen; ;
            DatesTextColorOutsideMonth = CustomColors.Green;

            NumberOfWeekTextColor = CustomColors.Green;
            OuterBorderWidth = 1;

            SelectedBorderWidth = 0;
            SelectedBorderColor = CustomColors.Green;

            Padding = new Thickness(0,10,0,10);

            TitleLabelTextColor = CustomColors.Yellow;
            TitleLeftArrowBorderRadius =
                TitleRightArrowBorderRadius = Device.OS != TargetPlatform.Android ? 40 : 0;
            TitleLeftArrowBorderWidth =
                TitleRightArrowBorderWidth = Device.OS != TargetPlatform.Android ? 2 : 0;
            TitleLeftArrowBorderColor =
                TitleRightArrowBorderColor =
                    Device.OS != TargetPlatform.Android ? CustomColors.Yellow : CustomColors.Green;
            TitleLeftArrowTextColor =
                TitleRightArrowTextColor = CustomColors.Yellow;

            StartDay = DayOfWeek.Monday;
            WeekdaysTextColor = CustomColors.Yellow;
            Opacity = 0;

            SpecialDates = _model.FilledDays;

            DateClicked += (sender, args) =>
            {
                if (IsSelectionEnabled(args.DateTime))
                {
                    _model.SelectedDateTime = args.DateTime;
                    _model.DateSelectAction.Invoke();
                }
            };
            _currentMounth = _model.SelectedDateTime.Month;

            MonthYearButtonClicked += (sender, args) =>
            {
                MonthChanged(args.DateTime);
            };
            LeftArrowClicked += (sender, args) =>
            {
                MonthChanged(args.DateTime);
            };
            RightArrowClicked += (sender, args) =>
            {
                MonthChanged(args.DateTime);
            };
        }

        public void RedrawSpecialDates()
        {
            SpecialDates = _model.FilledDays;
            this.RaiseSpecialDatesChanged();
        }

        private void MonthChanged(DateTime date)
        {
            _currentMounth = date.Month;
            _model.MounthChangedAction.Invoke(date);
        }

        private bool IsSelectionEnabled(DateTime date)
        {
            return date.Month == _currentMounth;
        }
    }
}
