using System;
using Xamarin.Forms;

namespace MySleepBook.Infrastructure.Naviagation
{
    public static class NaviagationService
    {
        public static NavigationPage CreateNavigationPage(Type pageType)
        {
            return new NavigationPage((Page) Activator.CreateInstance(pageType))
            {
                BarBackgroundColor = Color.FromHex("#009788"),
                HeightRequest = 50,
                BarTextColor = Color.White
            };
        }
    }
}
