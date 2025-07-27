using Microsoft.Maui.Controls;
using WordLearningApp.Views;

namespace WordLearningApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DeckPage), typeof(DeckPage));
        }
    }
}
