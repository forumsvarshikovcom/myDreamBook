using System.Threading.Tasks;
using MySleepBook.ViewModels;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace MySleepBook.Views
{
    public partial class WelcomePage : ContentPage
    {
        private readonly uint _animationFadeDuration = 1000;
        private readonly int _animationNextAnimationDuration = 500;
        public WelcomePage()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve(typeof(WelcomePageViewModel),"welcomePageViewModel") as WelcomePageViewModel;
        }

        public async Task LaunchAnimation(View elem)
        {
            await elem.FadeTo(0, _animationFadeDuration, Easing.Linear);
            await elem.FadeTo(1, _animationFadeDuration, Easing.Linear);
        }

        protected override void OnAppearing()
        {
            Task.Run(async () =>
            {
                Star_First.FadeTo(1, _animationFadeDuration/2, Easing.Linear);
                Star_Second.FadeTo(1, _animationFadeDuration / 2, Easing.Linear);
                Star_Third.FadeTo(1, _animationFadeDuration / 2, Easing.Linear);
                Star_Forth.FadeTo(1, _animationFadeDuration / 2, Easing.Linear);
                Star_Fifth.FadeTo(1, _animationFadeDuration / 2, Easing.Linear);
                Star_Six.FadeTo(1, _animationFadeDuration / 2, Easing.Linear);
                Star_Seventh.FadeTo(1, _animationFadeDuration / 2, Easing.Linear);
                Star_Eight.FadeTo(1, _animationFadeDuration / 2, Easing.Linear);

                while (true)
                {
                    await Task.Delay(_animationNextAnimationDuration);
                    LaunchAnimation(Star_First);
                    LaunchAnimation(Star_Fifth);
                    await Task.Delay(_animationNextAnimationDuration);
                    LaunchAnimation(Star_Second);
                    LaunchAnimation(Star_Six);
                    await Task.Delay(_animationNextAnimationDuration);
                    LaunchAnimation(Star_Third);
                    LaunchAnimation(Star_Seventh);
                    await Task.Delay(_animationNextAnimationDuration);
                    LaunchAnimation(Star_Forth);
                    LaunchAnimation(Star_Eight);
                }
            });
        }
    }
}
