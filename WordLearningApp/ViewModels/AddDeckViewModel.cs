using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace WordLearningApp.ViewModels
{
    public partial class AddDeckViewModel : ObservableObject
    {
        [ObservableProperty]
        private string deckName;

        public AddDeckViewModel() { }

        [RelayCommand]
        async Task AddDeck()
        {
            if (!string.IsNullOrWhiteSpace(DeckName))
            {
                WeakReferenceMessenger.Default.Send(new Messages.DeckAddedMessage(DeckName));
                await Shell.Current.Navigation.PopModalAsync();
            }
        }

        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
