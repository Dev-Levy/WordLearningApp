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
        private readonly Lang src, dst;

        public event Action<Word?> OnResultReturned;

        public AddWordViewModel()
        {

        }
        public AddWordViewModel(Deck deck)
        {
            src = deck.SrcLanguage;
            dst = deck.DstLanguage;
        }

        [RelayCommand]
        async Task AddWord()
        {
            if (!string.IsNullOrWhiteSpace(Term) && !string.IsNullOrWhiteSpace(Translation))
            {
                Word word = new(Term, Translation, src, dst);
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
