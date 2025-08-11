using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WordLearningApp.Models;
using WordLearningApp.Services.Database;
using WordLearningApp.Views;

namespace WordLearningApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly IDatabaseService db;

        [ObservableProperty]
        private ObservableCollection<Deck> decks = [];

        public MainPageViewModel() { }
        public MainPageViewModel(IDatabaseService databaseService)
        {
            db = databaseService;
            LoadDecksCommand.ExecuteAsync(null);
        }

        [RelayCommand]
        private async Task LoadDecksAsync()
        {
            var decks = await db.GetDecksAsync();
            Decks.Clear();
            foreach (var deck in decks)
            {
                deck.Words = [.. await db.GetWordsForDeckAsync(deck.Id)];
                Decks.Add(deck);
            }
        }

        [RelayCommand]
        async Task GoToDeckPage(Deck deck)
        {
            await Shell.Current.GoToAsync(nameof(DeckPage), false, new Dictionary<string, object> { { "SelectedDeck", deck } });
        }

        [RelayCommand]
        async Task ShowAddDeckPage()
        {
            AddDeckViewModel vm = new();
            AddDeckPage page = new(vm);

            vm.OnResultReturned += HandleModalResult;

            await Shell.Current.Navigation.PushModalAsync(page);

            void HandleModalResult(Deck newDeck)
            {
                vm.OnResultReturned -= HandleModalResult;

                if (newDeck != null)
                {
                    Decks.Add(newDeck);
                    _ = db.SaveDeckAsync(newDeck); // Fire-and-forget async operation haha
                    Debug.WriteLine("Added deck in VM: " + GetHashCode());
                    Debug.WriteLine("Deck count: " + Decks.Count);
                }
            }
        }

        [RelayCommand]
        async Task DeleteDeck(Deck deck)
        {
            if (deck == null)
                return;

            bool confirm = await Application.Current.MainPage
                .DisplayAlert("Delete Deck", $"Are you sure you want to delete '{deck.Name}'?", "Yes", "No");

            if (!confirm)
                return;

            Decks.Remove(deck);

            await db.DeleteDeckAsync(deck);
        }
    }
}
