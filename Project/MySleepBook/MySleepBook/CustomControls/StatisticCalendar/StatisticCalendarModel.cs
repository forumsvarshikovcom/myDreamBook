using System;
using System.Collections.Generic;
using XamForms.Controls;

namespace MySleepBook.CustomControls.StatisticCalendar
{
    public class StatisticCalendarModel
    {
        public DateTime SelectedDateTime { get; set; }
        public Action DateSelectAction { get; set; }
        public Action RedrawSpecialDatesAction { get; set; }
        public Action<DateTime> MounthChangedAction { get; set; }
        public List<SpecialDate> FilledDays { get; set; }
    }
}
