using System.IO;
using Windows.Storage;
using MySleepBook.Infrastructure.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(MySleepBook.UWP.DependencyServices.SQLite))]
namespace MySleepBook.UWP.DependencyServices
{
    public class SQLite: ISQLite
    {
        public SQLite() { }
        public string GetDatabasePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
