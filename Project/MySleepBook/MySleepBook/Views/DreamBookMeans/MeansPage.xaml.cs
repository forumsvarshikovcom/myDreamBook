using ConsoleApplication4;
using MySleepBook.CustomControls;
using MySleepBook.Infrastructure.Constants;
using MySleepBook.Infrastructure.Resourses;
using Xamarin.Forms;

namespace MySleepBook.Views.DreamBookMeans
{
    public partial class MeansPage : TabbedPage
    {
        public MeansPage(string selectedAutoCompleteItem)
        {
            InitializeComponent();
            Title = selectedAutoCompleteItem;
            var key = selectedAutoCompleteItem.ToLatinica();

            BarTextColor = Color.White;
            BarBackgroundColor = CustomColors.Green;

            var millerMean = Miller.ResourceManager.GetString(key);
            if (!string.IsNullOrEmpty(millerMean))
            {
                Children.Add(new MeansTabPage("Словарь Миллера", selectedAutoCompleteItem, millerMean));
            }
            var freidMean = Freid.ResourceManager.GetString(key);
            if (!string.IsNullOrEmpty(freidMean))
            {
                Children.Add(new MeansTabPage("Словарь Фрейда", selectedAutoCompleteItem, freidMean));
            }
            var hasseMean = Hasse.ResourceManager.GetString(key);
            if (!string.IsNullOrEmpty(hasseMean))
            {
                Children.Add(new MeansTabPage("Словарь Хассе", selectedAutoCompleteItem, hasseMean));
            }
        }
    }
}
