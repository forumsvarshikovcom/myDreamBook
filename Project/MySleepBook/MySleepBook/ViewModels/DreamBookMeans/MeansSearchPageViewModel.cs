using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MySleepBook.Infrastructure.Constants;
using MySleepBook.Infrastructure.Enums;
using MySleepBook.Infrastructure.Models;
using MySleepBook.Infrastructure.Resourses;
using MySleepBook.Views.DreamBookMeans;
using Xamarin.Forms;

namespace MySleepBook.ViewModels.DreamBookMeans
{
    public class MeansSearchPageViewModel: BaseViewModel
    {
        private List<AutocompleteItem> _autocompleteItems;
        private string _searchText, _selectedAutoCompleteItem, _description;
        private bool _autocompleteIsVisible, _descriptionIsVisible;
        private CancellationTokenSource _autoCompleteCancelTokenSource;
        private string _tempAutoCompleteSearchPhrase = String.Empty;

        public MeansSearchPageViewModel()
        {
            
        }

        public string SearchText
        {
            set
            {
                SetProperty(ref _searchText, value);
                var newTokenSource = new CancellationTokenSource();
                _autoCompleteCancelTokenSource?.Cancel();
                SearchTextChanged(newTokenSource.Token);
                _autoCompleteCancelTokenSource?.Dispose();
                _autoCompleteCancelTokenSource = newTokenSource;
            }
            get { return _searchText; }
        }

        public string SelectedAutoCompleteItem
        {
            set
            {
                SetProperty(ref _selectedAutoCompleteItem, value);
            }
            get { return _selectedAutoCompleteItem; }
        }

        public List<AutocompleteItem> AutocompleteItems
        {
            set { SetProperty(ref _autocompleteItems, value); }
            get { return _autocompleteItems ?? new List<AutocompleteItem>();}
        }

        public bool AutocompleteIsVisible
        {
            set { SetProperty(ref _autocompleteIsVisible, value); }
            get { return _autocompleteIsVisible; }
        }

        public bool DescriptionIsVisible
        {
            set { SetProperty(ref _descriptionIsVisible, value); }
            get { return _descriptionIsVisible; }
        }

        public string Description
        {
            set { SetProperty(ref _description, value); }
            get { return _description; }
        }

        private void SearchTextChanged(CancellationToken token)
        {
            Task.Delay(300, token).ContinueWith(tsk => 
            {
              if (!_autoCompleteCancelTokenSource.IsCancellationRequested && _tempAutoCompleteSearchPhrase != SearchText)
              {
                  _tempAutoCompleteSearchPhrase = SearchText;
                    if (SearchText.Length > 0)
                    {
                        MessagingCenter.Send<MeansSearchPageViewModel, AnimationTypes>(this,
                            MessagingCenterConstants.StartAnimation, AnimationTypes.HideSearchLogo);
                        var startWithKeys =
                            DreamBookDataConstants.DreamBookKeys.Where(x => x.Name.StartsWith(SearchText.ToLower()))
                                .ToList();
                        var containsKeys = SearchText.Length > 2
                            ? DreamBookDataConstants.DreamBookKeys.Where(
                                    x =>
                                        !x.Name.StartsWith(SearchText.ToLower()) &&
                                        x.Name.Contains(SearchText.ToLower()))
                                .ToList()
                            : null;

                        var keys = containsKeys != null
                            ? startWithKeys.Union(containsKeys).ToList()
                            : startWithKeys;

                        Device.BeginInvokeOnMainThread(() =>
                        {
                            AutocompleteIsVisible = keys.Any();
                            DescriptionIsVisible = !keys.Any();
                            Description = Common.txt_NotFound;
                            if (keys.Any())
                            {
                                AutocompleteItems = keys;
                            }
                        });
                    }
                    else
                    {
                        MessagingCenter.Send<MeansSearchPageViewModel, AnimationTypes>(this,
                            MessagingCenterConstants.StartAnimation, AnimationTypes.ShowSearchLogo);
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            AutocompleteIsVisible = false;
                            DescriptionIsVisible = true;
                            Description = Common.txt_SearchDescription;
                        });
                    }
                }
            });
        }

        public void SelectedItemOnChangeAsync()
        {
            if (!string.IsNullOrEmpty(SelectedAutoCompleteItem))
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PushAsync(new MeansPage(SelectedAutoCompleteItem));
                });
            }
        }
    }
}
