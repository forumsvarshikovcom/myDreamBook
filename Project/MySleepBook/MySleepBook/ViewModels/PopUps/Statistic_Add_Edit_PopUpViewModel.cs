using System;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MySleepBook.ViewModels.PopUps
{
    public class Statistic_Add_Edit_PopUpViewModel:BasePopUpViewModel
    {
        private double _goodSleepLineValue, _badSleepLineValue;
        public Command SaveCommand { get; set; }
        public Action SaveAction { get; set; }

        public Statistic_Add_Edit_PopUpViewModel()
        {
            SaveCommand = new Command(async () =>
            {
                await PopupNavigation.PopAllAsync(false);
                SaveAction.Invoke();
            });
        }

        public double GoodSleepLineValue
        {
            set { SetProperty(ref _goodSleepLineValue, value); }
            get { return Math.Round(_goodSleepLineValue, 2); }
        }

        public double BadSleepLineValue
        {
            set { SetProperty(ref _badSleepLineValue, value); }
            get { return Math.Round(_badSleepLineValue, 2); }
        }
    }
}
