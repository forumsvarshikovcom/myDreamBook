using SQLite;

namespace MySleepBook.DataManagers.LocalDbManager.Domain
{
    public class BaseEntity
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
    }
}
