using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WordLearningApp.Models;

namespace WordLearningApp.ViewModels
{
    public partial class DeckPageViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private ObservableCollection<Word> words;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("SelectedDeck", out var deck))
            {
                if (deck is Deck Deck)
                {
                    Title = Deck.Name;
                    Words = Deck.Words;
                }
            }
        }
    }
}
