using MySleepBook.DataManagers.LocalDbManager.Domain;

namespace MySleepBook.DataManagers.LocalDbManager.Repositories.Interfaces
{
    public interface IUserRepository: IBaseRepository<User>
    {
        void Test();
    }
}
