using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WordLearningApp.Models;
using WordLearningApp.Views;

namespace WordLearningApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Deck> decks;

        public MainPageViewModel()
        {
            Decks = PopulateDecks(); //this should be replaced by DB file load
        }
        private static ObservableCollection<Deck> PopulateDecks()
        {
            ObservableCollection<Deck> decks = [];
            Deck? currentDeck = null;

            string[] lines = """
                            #Animals;Hungarian;English
                            Macska;Cat
                            Kutya;Dog
                            Egér;Mouse
                            #Fruits;Hungarian;English
                            Alma;Apple
                            Körte;Pear
                            Narancs;Orange
                            """.Split(Environment.NewLine);

            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                if (line.StartsWith('#'))
                {
                    currentDeck = new Deck(name: values[0][1..],
                                    srcLanguage: Enum.Parse<Lang>(values[1]),
                                    dstLanguage: Enum.Parse<Lang>(values[2]));
                    decks.Add(currentDeck);
                }
                else
                {
                    currentDeck?.Words.Add(new(term: values[0],
                             translation: values[1],
                             srcLanguage: currentDeck.SrcLanguage,
                             dstLanguage: currentDeck.DstLanguage));
                }
            }

            return decks;
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
                    Debug.WriteLine("Added deck in VM: " + GetHashCode());
                    Debug.WriteLine("Deck count: " + Decks.Count);
                }
            }
        }

    }
}
