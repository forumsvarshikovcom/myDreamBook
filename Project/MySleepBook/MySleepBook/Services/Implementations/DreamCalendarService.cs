using System;
using System.Collections.Generic;
using System.Linq;
using MySleepBook.DataManagers.LocalDbManager.Domain;
using MySleepBook.DataManagers.LocalDbManager.Repositories.Interfaces;
using MySleepBook.Services.Interfaces;

namespace MySleepBook.Services.Implementations
{
    public class DreamCalendarService:IDreamCalendarService
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
    }
}
