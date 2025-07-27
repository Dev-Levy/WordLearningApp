namespace WordLearningApp.Models
{
    public class Word(string term, string translation, Lang srcLanguage, Lang dstLanguage)
    {
        public string Term { get; set; } = term;
        public string Translation { get; set; } = translation;
        public Lang SrcLanguage { get; set; } = srcLanguage;
        public Lang DstLanguage { get; set; } = dstLanguage;
    }

}
