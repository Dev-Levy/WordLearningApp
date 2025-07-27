using CommunityToolkit.Mvvm.Messaging.Messages;
using WordLearningApp.Models;

namespace WordLearningApp.Messages
{
    public class WordMessage(Word word) : ValueChangedMessage<Word>(word)
    {
        public Word MsgWord { get; } = word;
    }
}
