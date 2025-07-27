using Microsoft.Maui.Controls;
using WordLearningApp.Services.Database;

namespace WordLearningApp
{
    public partial class App : Application
    {
        private readonly IDatabaseService databaseService;
        public App(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
            InitializeComponent();
            InitializeDatabase();
            MainPage = new AppShell();
        }
        private async void InitializeDatabase()
        {
            await databaseService.InitializeDatabaseAsync();
        }
    }
}
