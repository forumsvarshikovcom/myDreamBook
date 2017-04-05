using MySleepBook.ViewModels.PopUps;
using Xamarin.Forms;

namespace MySleepBook.Views.PopUps
{
    public partial class Statistic_Add_Edit_PopUp: PopUpBase
    {
        private Statistic_Add_Edit_PopUpViewModel _viewModel;
        public Statistic_Add_Edit_PopUp(Statistic_Add_Edit_PopUpViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
            _viewModel.LayoutHeight = 300;
            _viewModel.LayoutWidth = 400;
            _viewModel.ExitIconBounds = new Rectangle(1.06, -0.06, 0.1, 0.1);
        }
    }
}
