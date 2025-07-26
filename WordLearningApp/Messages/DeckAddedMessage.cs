using CommunityToolkit.Mvvm.Messaging.Messages;

namespace WordLearningApp.Messages
{
    public class DeckAddedMessage(string value) : ValueChangedMessage<string>(value) { }
}
