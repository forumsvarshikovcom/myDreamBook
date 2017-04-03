using MySleepBook.DataManagers.LocalDbManager.Domain;
using MySleepBook.DataManagers.LocalDbManager.Repositories.Interfaces;

namespace MySleepBook.DataManagers.LocalDbManager.Repositories.Implementations
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository() { }

        public void Test()
        {
            var s = "ss";
        }
    }
}
