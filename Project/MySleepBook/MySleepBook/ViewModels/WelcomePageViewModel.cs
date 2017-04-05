using System.Windows.Input;
using MySleepBook.DataManagers.LocalDbManager.Repositories.Interfaces;
using MySleepBook.Infrastructure.Resourses;
using Xamarin.Forms;

namespace MySleepBook.ViewModels
{
    public class WelcomePageViewModel:BaseViewModel
    {
        private string _welcomeText;
        public ICommand ShareCommand => new Command(()=> {});

        private IUserRepository _userRepository;

        public WelcomePageViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string WelcomeText
        {
            set { SetProperty(ref _welcomeText, value); }
            get { return Common.txt_Welcom; }
        }
    }
}
