using Microsoft.Maui.Controls;
using WordLearningApp.ViewModels;

namespace WordLearningApp.Views;

public partial class AddWordPage : ContentPage
{
    public AddWordPage(AddWordViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}