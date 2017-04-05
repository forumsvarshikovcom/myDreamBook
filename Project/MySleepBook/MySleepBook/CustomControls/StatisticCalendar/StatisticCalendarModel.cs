using System;
using System.Collections.Generic;

namespace MySleepBook.CustomControls.StatisticCalendar
{
    public class StatisticCalendarModel
    {
        public DateTime SelectedDateTime { get; set; }
        public Action DateSelectAction { get; set; }
        public Action RedrawSpecialDatesAction { get; set; }
        public List<DateTime> FilledDays { get; set; }
    }
}
