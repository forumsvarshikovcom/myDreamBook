using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;

namespace MySleepBook.Views.PopUps
{
    public class PopUpBase: PopupPage
    {
        public PopUpBase()
        {
            Animation = new MoveAnimation(MoveAnimationOptions.Top, MoveAnimationOptions.Center);
        }
        protected override bool OnBackgroundClicked()
        {
            CloseAllPopup();
            return false;
        }
        private async void CloseAllPopup()
        {
            await Navigation.PopAllPopupAsync(false);
        }
    }
}
