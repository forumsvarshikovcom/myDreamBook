using MySleepBook.Views.PopUps;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MySleepBook.ViewModels.Statistics
{
    public class StatisticsPageViewModel:BaseViewModel
    {
        public ICommand ShowAddEditStatisticPopUp { get; set; }

        public StatisticsPageViewModel()
        {
            ShowAddEditStatisticPopUp = new Command(() =>
            {
                var page = new Statistic_Add_Edit_PopUp();

                PopupNavigation.PushAsync(page,false);
            });
        }
    }
}
