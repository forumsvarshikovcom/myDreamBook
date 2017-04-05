using System;

namespace MySleepBook.DataManagers.LocalDbManager.Domain
{
    public class DreamCalendar:BaseEntity
    {
        public string Date { get; set; }
        public double GoodDreamValue{ get; set; }
        public double BadDreamValue { get; set; }
    }
}
