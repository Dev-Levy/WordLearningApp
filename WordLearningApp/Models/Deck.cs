using SQLite;
using System.Collections.ObjectModel;

namespace WordLearningApp.Models
{
    [Table("Decks")]
    public class Deck()
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string Name { get; set; }
        [Ignore] public ObservableCollection<Word> Words { get; set; } = [];
        public Lang SrcLanguage { get; set; }
        public Lang DstLanguage { get; set; }
    }
}
