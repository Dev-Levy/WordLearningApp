using Microsoft.Maui.Storage;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WordLearningApp.Models;

namespace WordLearningApp.Services.Database
{
    class DatabaseService : IDatabaseService
    {
        private readonly SQLiteAsyncConnection database;
        public DatabaseService()
        {
            database = new SQLiteAsyncConnection(DatabasePath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);
        }

        //TODO: exception handling

        private static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, "WordLearning.db3");
        public async Task InitializeDatabaseAsync()
        {
            await database.CreateTableAsync<Deck>();
            await database.CreateTableAsync<Word>();
        }
        public async Task<Deck> GetDeckAsync(int id)
        {
            var deck = await database.Table<Deck>()
                            .Where(d => d.Id == id)
                            .FirstOrDefaultAsync();

            if (deck != null)
            {
                deck.Words = [.. await GetWordsForDeckAsync(deck.Id)];
            }

            return deck;
        }
        public async Task<List<Deck>> GetDecksAsync()
        {
            return await database.Table<Deck>().ToListAsync();
        }
        public async Task<int> SaveDeckAsync(Deck deck)
        {
            if (deck.Id == 0)
                return await database.InsertAsync(deck);
            else
                return await database.UpdateAsync(deck);
        }
        public async Task<int> DeleteDeckAsync(Deck deck)
        {
            await database.Table<Word>().Where(w => w.DeckId == deck.Id).DeleteAsync();

            return await database.DeleteAsync(deck);
        }
        public async Task<int> SaveWordAsync(Word word)
        {
            if (word.Id == 0)
            {
                return await database.InsertAsync(word);
            }
            else
            {
                return await database.UpdateAsync(word);
            }
        }
        public async Task<List<Word>> GetWordsForDeckAsync(int deckId)
        {
            return await database.Table<Word>().Where(w => w.DeckId == deckId).ToListAsync();
        }
        public async Task<int> DeleteWordAsync(Word word)
        {
            return await database.DeleteAsync(word);
        }
    }
}
