using System.Collections.Generic;
using System.Threading.Tasks;
using WordLearningApp.Models;

namespace WordLearningApp.Services.Database
{
    public interface IDatabaseService
    {
        Task InitializeDatabaseAsync();
        Task<List<Deck>> GetDecksAsync();
        Task<Deck> GetDeckAsync(int id);
        Task<int> SaveDeckAsync(Deck deck);
        Task<int> DeleteDeckAsync(Deck deck);
        Task<List<Word>> GetWordsForDeckAsync(int deckId);
        Task<int> SaveWordAsync(Word word);
        Task<int> DeleteWordAsync(Word word);
    }
}
