﻿using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace MySleepBook.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(480, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            LoadApplication(new MySleepBook.App());
        }
    }
}
