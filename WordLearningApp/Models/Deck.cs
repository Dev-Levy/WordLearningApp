using System.Collections.ObjectModel;

namespace WordLearningApp.Models
{
    public class Deck(string name, Lang srcLanguage, Lang dstLanguage)
    {
        public string Name { get; set; } = name;
        public ObservableCollection<Word> Words { get; set; } = [];
        public Lang SrcLanguage { get; set; } = srcLanguage;
        public Lang DstLanguage { get; set; } = dstLanguage;
    }
}
