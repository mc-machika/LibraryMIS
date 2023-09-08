using LibraryMIS.Services.BookAPI.Models;
using LibraryMIS.Services.BookAPI.MongodbConfigurations;
using LibraryMIS.Services.BookAPI.Service.IService;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LibraryMIS.Services.BookAPI.Service
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<Book> _bookCollection;

        public BookService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _bookCollection = mongoDb.GetCollection<Book>(databaseSettings.Value.CollectionName);
        }

        public async Task CreateBookAsync(Book book) => await _bookCollection.InsertOneAsync(book);

        public async Task<List<Book>> GetAllBooksAsync() => await _bookCollection.Find(_ => true).ToListAsync();


        public async Task<Book> GetBookAsync(string id) => await _bookCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task RemoveBookAsync(string id) => await _bookCollection.DeleteOneAsync(x => x.Id == id);

        public async Task UpdateBookAsync(Book book) => await _bookCollection.ReplaceOneAsync(x => x.Id == book.Id, book);
    }
}
