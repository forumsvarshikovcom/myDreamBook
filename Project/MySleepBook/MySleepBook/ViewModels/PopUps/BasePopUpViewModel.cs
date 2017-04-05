using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace MySleepBook.ViewModels.PopUps
{
    public class BasePopUpViewModel:BaseViewModel
    {
        private Rectangle _exitIconBounds;

        public Command ClosePopUpCommand { get; set; }

        public BasePopUpViewModel()
        {
            ClosePopUpCommand = new Command(async () => await Navigation.PopAllPopupAsync());
        }

        public Rectangle ExitIconBounds
        {
            set { SetProperty(ref _exitIconBounds, value); }
            get
            {
                return Device.OS == TargetPlatform.Android
                    ? new Rectangle(1.125, -0.125, 0.2, 0.2)
                    : new Rectangle(1.2, -0.12, 0.2, 0.2);
            }
        }
    }
}
