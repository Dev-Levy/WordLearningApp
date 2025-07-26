using Microsoft.Maui.Controls;
using WordLearningApp.ViewModels;

namespace WordLearningApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }

}
