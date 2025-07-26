using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WordLearningApp.Messages;
using WordLearningApp.Models;
using WordLearningApp.Views;

namespace WordLearningApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<Deck> Decks { get; set; } = [];

        public MainPageViewModel()
        {
            Decks.Add(new Deck
            {
                Name = "Animals",
                Words =
                [
                    new Word { Term = "Cat", Definition = "A small domesticated carnivorous mammal" },
                    new Word { Term = "Dog", Definition = "A domesticated carnivorous mammal" }
                ]
            });

            Decks.Add(new Deck
            {
                Name = "Fruits",
                Words =
                [
                    new Word { Term = "Apple", Definition = "A round fruit with red or green skin" },
                    new Word { Term = "Banana", Definition = "A long curved fruit" }
                ]
            });

            WeakReferenceMessenger.Default.Register<DeckAddedMessage>(this, (r, m) =>
            {
                Decks.Add(new Deck { Name = m.Value });
            });
        }

        [RelayCommand]
        async Task GoToDeckPage(Deck deck)
        {
            System.Diagnostics.Debug.WriteLine($"SelectedDeck changed: {deck?.Name}");
            await Shell.Current.GoToAsync(nameof(DeckPage), false, new Dictionary<string, object>
            {
                { "SelectedDeck", deck }
            });
        }

        [RelayCommand]
        async Task ShowAddDeckPage()
        {
            await Shell.Current.Navigation.PushModalAsync(new AddDeckPage());
        }
    }
}
