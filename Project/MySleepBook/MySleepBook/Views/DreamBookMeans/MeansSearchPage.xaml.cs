using System.Threading.Tasks;
using MySleepBook.Infrastructure.Constants;
using MySleepBook.Infrastructure.Enums;
using MySleepBook.Infrastructure.Models;
using MySleepBook.Infrastructure.Resourses;
using MySleepBook.ViewModels.DreamBookMeans;
using Xamarin.Forms;

namespace MySleepBook.Views.DreamBookMeans
{
    public partial class MeansSearchPage : ContentPage
    {
        private MeansSearchPageViewModel _viewModel = null;
        private readonly uint _translateAnimationDuration = 150;
        private readonly uint _fadeAnimationDuration = 150;
        public MeansSearchPage()
        {
            InitializeComponent();
            _viewModel = new MeansSearchPageViewModel();
            _viewModel.Navigation = Navigation;
            _viewModel.Description = Common.txt_SearchDescription;
            _viewModel.DescriptionIsVisible = true;
            BindingContext = _viewModel;
            ContentWrapper.TranslateTo(0, 100, 0);
            Image_Search.FadeTo(1, 0);
        }

        private void Hide_Search_Animation()
        {
            ContentWrapper.TranslateTo(0, 0, _translateAnimationDuration);
            Image_Search.FadeTo(0, _fadeAnimationDuration / 2);
        }

        private void Show_Search_Animation()
        {
            ContentWrapper.TranslateTo(0, 90, _translateAnimationDuration);
            Image_Search.FadeTo(1, _fadeAnimationDuration * 2);
        }

        //private void Hide_NoResult_Animation()
        //{
        //    ContentWrapper.TranslateTo(0, 0, _translateAnimationDuration);
        //    Image_NoResult.FadeTo(0, _fadeAnimationDuration / 2);
        //}

        //private void Show_NoResult_Animation()
        //{
        //    ContentWrapper.TranslateTo(0, 100, _translateAnimationDuration);
        //    Image_NoResult.FadeTo(1, _fadeAnimationDuration / 2);
        //}

        private void Autocomplete_OnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            var listView = (sender as ListView);
            if (listView != null && (listView.SelectedItem as AutocompleteItem) != null)
            {
                _viewModel.SelectedAutoCompleteItem = (listView.SelectedItem as AutocompleteItem).Name;
                (sender as ListView).SelectedItem = null;
                _viewModel.SelectedItemOnChangeAsync();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<MeansSearchPageViewModel, AnimationTypes>(this, MessagingCenterConstants.StartAnimation,
                (sender, type) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        switch (type)
                        {
                            case AnimationTypes.ShowSearchLogo:
                                Show_Search_Animation();
                                break;
                            case AnimationTypes.HideSearchLogo:
                                Hide_Search_Animation();
                                break;
                        }
                    });
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<MeansSearchPageViewModel, AnimationTypes>(this, MessagingCenterConstants.StartAnimation);
        }
    }
}
