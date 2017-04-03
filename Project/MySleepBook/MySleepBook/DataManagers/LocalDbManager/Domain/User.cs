using SQLite;

namespace MySleepBook.DataManagers.LocalDbManager.Domain
{
    [Table("Users")]
    public class User : BaseEntity
    {
        public int AccountId { get; set; }
        public string Login { get; set; }
    }
}
