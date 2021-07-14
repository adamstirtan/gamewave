using Xamarin.Forms;

using FinalBoss.ViewModels;

namespace FinalBoss.Views
{
    public partial class SearchPage : ContentPage
    {
        private readonly SearchViewModel _viewModel;

        public SearchPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new SearchViewModel();
        }
    }
}