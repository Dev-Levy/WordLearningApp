using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using WordLearningApp.Models;

namespace WordLearningApp.ViewModels
{
    public partial class AddWordViewModel : ObservableObject
    {
        [ObservableProperty] private string term;
        [ObservableProperty] private string translation;
        private readonly Deck deck;

        public event Action<Word?> OnResultReturned;

        public AddWordViewModel() { }
        public AddWordViewModel(Deck deck)
        {
            this.deck = deck;
        }

        [RelayCommand]
        async Task AddWord()
        {
            if (!string.IsNullOrWhiteSpace(Term) && !string.IsNullOrWhiteSpace(Translation))
            {
                Word word = new()
                {
                    Term = Term,
                    Translation = Translation,
                    SrcLanguage = deck.SrcLanguage,
                    DstLanguage = deck.DstLanguage,
                    DeckId = deck.Id
                };
                OnResultReturned?.Invoke(word);
                await Shell.Current.Navigation.PopModalAsync();
            }
        }

        [RelayCommand]
        async Task Cancel()
        {
            OnResultReturned?.Invoke(null);
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
