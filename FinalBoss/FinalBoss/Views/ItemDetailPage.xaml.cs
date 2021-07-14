using System.ComponentModel;
using FinalBoss.ViewModels;
using Xamarin.Forms;

namespace FinalBoss.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}