using Xamarin.Forms;
using System;
using System.IO;
using MySleepBook.Infrastructure.DependencyService;

[assembly: Dependency(typeof(MySleepBook.Droid.DependencyServices.SQLite))]
namespace MySleepBook.Droid.DependencyServices
{
    public class SQLite: ISQLite
    {
        public SQLite() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}