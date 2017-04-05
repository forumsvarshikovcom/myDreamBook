using MySleepBook.DataManagers.LocalDbManager.Domain;
using MySleepBook.DataManagers.LocalDbManager.Repositories.Interfaces;

namespace MySleepBook.DataManagers.LocalDbManager.Repositories.Implementations
{
    public class DreamCalendarRepository: BaseRepository<DreamCalendar>, IDreamCalendarRepository
    {
        public DreamCalendarRepository() { }
    }
}
