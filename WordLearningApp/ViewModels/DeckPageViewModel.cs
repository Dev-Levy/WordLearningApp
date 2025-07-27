using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WordLearningApp.Models;
using WordLearningApp.Views;

namespace WordLearningApp.ViewModels
{
    public partial class DeckPageViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Deck currentDeck;

        public DeckPageViewModel() { }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("SelectedDeck", out var queryDeck) && queryDeck is Deck receivedDeck)
            {
                CurrentDeck = receivedDeck;
            }
        }

        [RelayCommand]
        async Task ShowAddWordPage()
        {
            AddWordViewModel modalVm = new(CurrentDeck);
            AddWordPage modalPage = new(modalVm);

            modalVm.OnResultReturned += HandleModalResult;

            await Shell.Current.Navigation.PushModalAsync(modalPage);

            void HandleModalResult(Word newWord)
            {
                modalVm.OnResultReturned -= HandleModalResult;

                if (newWord != null)
                {
                    CurrentDeck.Words.Add(newWord);
                    Debug.WriteLine("Added word in VM: " + GetHashCode());
                    Debug.WriteLine("Word count: " + CurrentDeck.Words.Count);
                }
            }
        }
    }
}
