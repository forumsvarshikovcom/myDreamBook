﻿using Microsoft.Practices.Unity;
using MySleepBook.DataManagers.LocalDbManager.Repositories.Implementations;
using MySleepBook.DataManagers.LocalDbManager.Repositories.Interfaces;
using MySleepBook.Services.Implementations;
using MySleepBook.Services.Interfaces;
using MySleepBook.Views.MasterDetailPage;
using Xamarin.Forms;

namespace MySleepBook
{
    public partial class App : Application
    {
        public static UnityContainer Container { get; set; }
        public App()
        {
            InitializeComponent();
            ResolveDependency();
            MainPage = new MainPage();
        }

        private static void ResolveDependency()
        {
            Container = new UnityContainer();
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<IDreamCalendarRepository, DreamCalendarRepository>();
            Container.RegisterType<IDreamCalendarService, DreamCalendarService>();
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
