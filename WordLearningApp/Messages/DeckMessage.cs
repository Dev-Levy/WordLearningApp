using CommunityToolkit.Mvvm.Messaging.Messages;
using WordLearningApp.Models;

namespace WordLearningApp.Messages
{
    public class DeckMessage(Deck deck, string token) : ValueChangedMessage<Deck>(deck)
    {
        public string Token { get; } = token;
        public Deck MsgDeck { get; } = deck;
    }
}
