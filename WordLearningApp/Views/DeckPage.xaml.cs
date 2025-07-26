using Microsoft.Maui.Controls;
using WordLearningApp.ViewModels;

namespace WordLearningApp.Views;

public partial class DeckPage : ContentPage
{
    public DeckPage(DeckPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}