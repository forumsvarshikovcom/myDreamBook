using System;
using System.Collections.Generic;
using MySleepBook.DataManagers.LocalDbManager.Domain;
using MySleepBook.Infrastructure.Models;

namespace MySleepBook.Services.Interfaces
{
    public interface IDreamCalendarService
    {
        DreamCalendar GetStatisticPerDay(DateTime day);
        List<DreamCalendar> GetStatisticPerMounth(DateTime date);
        void CreateStatisticPerDay(DreamCalendar statistic);
        void UpdateStatisticPerDay(DreamCalendar statistic);
        SeriasForChart GetSeriasForChart(bool forWeek, DateTime currentDay);
    }
}
