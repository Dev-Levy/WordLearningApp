using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WordLearningApp.Models;

namespace WordLearningApp.ViewModels
{
    public partial class AddDeckViewModel : ObservableObject
    {
        public ObservableCollection<Lang> Languages { get; } = [.. Enum.GetValues<Lang>()];

        [ObservableProperty] private string deckName;
        [ObservableProperty] private Lang selectedSourceLanguage;
        [ObservableProperty] private Lang selectedTargetLanguage;

        public event Action<Deck?> OnResultReturned;
        public AddDeckViewModel() { }

        [RelayCommand]
        async Task AddDeck()
        {
            if (!string.IsNullOrWhiteSpace(DeckName))
            {
                Deck deck = new()
                {
                    Name = DeckName,
                    SrcLanguage = SelectedSourceLanguage,
                    DstLanguage = SelectedTargetLanguage
                };
                OnResultReturned?.Invoke(deck);
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
