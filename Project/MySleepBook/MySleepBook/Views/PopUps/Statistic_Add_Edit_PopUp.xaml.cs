using System;
using MySleepBook.ViewModels.PopUps;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace MySleepBook.Views.PopUps
{
    public partial class Statistic_Add_Edit_PopUp : PopupPage
    {
        public Statistic_Add_Edit_PopUp()
        {
            InitializeComponent();
            BindingContext =
                App.Container.Resolve(typeof(BasePopUpViewModel), "basePopUpViewModel") as BasePopUpViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            FrameContainer.HeightRequest = -1;

            CloseImage.Rotation = 30;
            CloseImage.Scale = 0.3;
            CloseImage.Opacity = 0;

            CloseImage.FadeTo(1);
            CloseImage.ScaleTo(1, easing: Easing.SpringOut);
            CloseImage.RotateTo(0);

        }

        private void OnCloseButtonTapped(object sender, EventArgs e)
        {
            CloseAllPopup();
        }
        protected override bool OnBackgroundClicked()
        {
            CloseAllPopup();
            return false;
        }
        private async void CloseAllPopup()
        {
            CloseImage.FadeTo(0);
            CloseImage.ScaleTo(0.3, easing: Easing.SpringOut);
            CloseImage.RotateTo(-30);
            await Navigation.PopAllPopupAsync();
        }
    }
}
