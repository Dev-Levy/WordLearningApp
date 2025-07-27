using SQLite;

namespace WordLearningApp.Models
{
    [Table("Words")]
    public class Word
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string Term { get; set; }
        public string Translation { get; set; }
        public Lang SrcLanguage { get; set; }
        public Lang DstLanguage { get; set; }

        [Indexed] public int DeckId { get; set; } //FK
    }

}
