using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace MySleepBook.ViewModels.PopUps
{
    public class BasePopUpViewModel : BaseViewModel
    {
        private Rectangle _exitIconBounds;

        public Command ClosePopUpCommand { get; set; }
        private int _layoutHeight;
        private int _layoutWidth;

        public BasePopUpViewModel()
        {
            ClosePopUpCommand = new Command(async () => await Navigation.PopAllPopupAsync(false));
            LayoutHeight = 150;
            LayoutWidth = 300;
            ExitIconBounds = Device.OS == TargetPlatform.Android
                    ? new Rectangle(1.125, -0.125, 0.2, 0.2)
                    : new Rectangle(1.2, -0.12, 0.2, 0.2);
        }
        public Rectangle ExitIconBounds
        {
            set { SetProperty(ref _exitIconBounds, value); }
            get { return _exitIconBounds; }
        }

        public int LayoutWidth
        {
            set { SetProperty(ref _layoutWidth, value); }
            get { return _layoutWidth; }
        }

        public int LayoutHeight
        {
            set { SetProperty(ref _layoutHeight, value); }
            get { return _layoutHeight; }
        }
    }
}
