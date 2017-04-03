using MySleepBook.Infrastructure.Constants;
using Xamarin.Forms;

namespace MySleepBook.CustomControls
{
    public class MeansTabPage : ContentPage
    {
        public MeansTabPage(string title, string key, string content)
        {
            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = $"{key.ToUpper()} ({title.ToLower()})",
                            TextColor = CustomColors.Green,
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                            Margin = new Thickness(0,30,0,0)
                        },
                        new Label
                        {
                            Text = content,
                            TextColor = CustomColors.Blue,
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            Margin = new Thickness(0,20,0,0)
                        },
                        new Button
                        {
                            Text = "Добавить в закладки",
                            TextColor = Color.White,
                            BackgroundColor = CustomColors.Blue,
                            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                            WidthRequest = 150,
                            Margin = new Thickness(0,30,0,30)
                        }
                    }
                }
            };
            Title = title;
        }
    }
}
