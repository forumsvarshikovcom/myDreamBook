using System;
using System.Collections.Generic;
using MySleepBook.Infrastructure.Constants;
using MySleepBook.Infrastructure.Naviagation;
using MySleepBook.Views.DreamBookMeans;
using MySleepBook.Views.Statistic;
using NavigationMasterDetail.MenuItems;
using Xamarin.Forms;

namespace MySleepBook.Views.MasterDetailPage {

    public partial class MainPage : Xamarin.Forms.MasterDetailPage {

        public List<MasterPageItem> menuList { get; set; }

        public MainPage() {

            InitializeComponent();

            menuList = new List<MasterPageItem>
            {
                new MasterPageItem {Title = "Сонник", Icon = "dreamBook_menuIcon.png", TargetType = typeof(MeansSearchPage)},
                new MasterPageItem {Title = "Закладки", Icon = "dreamBook_menuIcon.png", TargetType = typeof(MeansSearchPage)},
                new MasterPageItem {Title = "Календарь", Icon = "dreamBook_menuIcon.png", TargetType = typeof(StatisticPage)}
            };

            navigationDrawerList.ItemsSource = menuList;
            Detail = NaviagationService.CreateNavigationPage(typeof(WelcomePage));
            if (Device.OS != TargetPlatform.Android)
            {
                Icon = "Assets/burger.png";
            }
            MasterBehavior = MasterBehavior.Popover;
        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e) {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = NaviagationService.CreateNavigationPage(page);
            IsPresented = false;
        }
    }
}
