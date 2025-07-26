using System.Collections.ObjectModel;

namespace WordLearningApp.Models
{
    public class Deck
    {
        public string Name { get; set; }
        public ObservableCollection<Word> Words { get; set; } = new();
    }
}
