using System;
using System.Collections.Generic;
using System.Linq;
using MySleepBook.CustomControls.Chart;
using MySleepBook.DataManagers.LocalDbManager.Domain;
using MySleepBook.DataManagers.LocalDbManager.Repositories.Interfaces;
using MySleepBook.Infrastructure.Constants;
using MySleepBook.Infrastructure.Models;
using MySleepBook.Services.Interfaces;

namespace MySleepBook.Services.Implementations
{
    public class DreamCalendarService : IDreamCalendarService
    {
        private IDreamCalendarRepository _dreamCalendarRepository;

        public DreamCalendarService(IDreamCalendarRepository dreamCalendarRepository)
        {
            _dreamCalendarRepository = dreamCalendarRepository;
        }
        public DreamCalendar GetStatisticPerDay(DateTime day)
        {
            var formatedDate = day.ToString("d");
            var statistic = _dreamCalendarRepository.GetQuery(x => x.Date == formatedDate).FirstOrDefault();
            return statistic;
        }

        public List<DreamCalendar> GetStatisticPerMounth(DateTime date)
        {
            var formatedDates = Enumerable.Range(1, DateTime.DaysInMonth(date.Year, date.Month))
                .Select(day => new DateTime(date.Year, date.Month, day).ToString("d"));
            return _dreamCalendarRepository.GetQuery(x => formatedDates.Contains(x.Date)).ToList();
        }

        public void CreateStatisticPerDay(DreamCalendar statistic)
        {
            _dreamCalendarRepository.Create(statistic);
        }

        public void UpdateStatisticPerDay(DreamCalendar statistic)
        {
            _dreamCalendarRepository.Update(statistic);
        }

        public SeriasForChart GetSeriasForChart(bool forWeek, DateTime currentDay)
        {
            var goodDreamPoints = new DataPointCollection();
            var badDreamPoints = new DataPointCollection();
            var freecPoints = new DataPointCollection();


            var period = forWeek ? GetCurrentWeek(currentDay) : new List<DateTime>();
            var formatedDates = period.Select(day => new DateTime(day.Year, day.Month, day.Day).ToString("d")).ToList();
            var statistics = _dreamCalendarRepository.GetQuery(x => formatedDates.Contains(x.Date)).ToList();

            for (var i = 0; i < period.Count; i++)
            {

                goodDreamPoints.Add(new DataPoint
                {
                    Label = DreamBookDataConstants.WeekNames[period[i].DayOfWeek],
                    Value = statistics.Any(x => x.Date == period[i].ToString("d"))
                        ? statistics.FirstOrDefault(x => x.Date == period[i].ToString("d")).GoodDreamValue
                        : 1
                });
                badDreamPoints.Add(new DataPoint
                {
                    Label = DreamBookDataConstants.WeekNames[period[i].DayOfWeek],
                    Value = statistics.Any(x => x.Date == period[i].ToString("d"))
                        ? statistics.FirstOrDefault(x => x.Date == period[i].ToString("d")).BadDreamValue
                        : 1
                });
                freecPoints.Add(new DataPoint
                {
                    Label = DreamBookDataConstants.WeekNames[period[i].DayOfWeek],
                    Value = i >= 5 ? 5 : i
                });
            }
            return new SeriasForChart
            {
                BadDreamPoints = badDreamPoints,
                GoodDreamPoints = goodDreamPoints,
                FreecPoints = freecPoints
            };
        }

        private List<DateTime> GetCurrentWeek(DateTime currentDay)
        {
            var currentWeek = new List<DateTime>();
            while (true)
            {
                if (currentDay.DayOfWeek != DayOfWeek.Monday)
                {
                    currentDay = currentDay.AddDays(-1);
                }
                else
                {
                    var endDate = currentDay.AddDays(6);
                    var startDate = currentDay;
                    currentWeek = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
                      .Select(x => startDate.AddDays(x))
                      .ToList();
                    break;
                }
            }
            return currentWeek;
        }
    }
}
