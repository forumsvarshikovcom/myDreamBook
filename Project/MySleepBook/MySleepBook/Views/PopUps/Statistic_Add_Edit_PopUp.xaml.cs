using System;
using MySleepBook.ViewModels.PopUps;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace MySleepBook.Views.PopUps
{
    public partial class Statistic_Add_Edit_PopUp: PopUpBase
    {
        private BasePopUpViewModel _viewModel;
        public Statistic_Add_Edit_PopUp()
        {
            InitializeComponent();
            _viewModel = App.Container.Resolve(typeof(BasePopUpViewModel), "basePopUpViewModel") as BasePopUpViewModel;
            BindingContext = _viewModel;
        }
    }
}
