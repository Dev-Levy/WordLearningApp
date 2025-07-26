using Microsoft.Maui.Controls;

namespace WordLearningApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
