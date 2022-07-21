
using Bookstore.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace BooksApi
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Book> _books;

        public DbClient(IOptions<BookstoreDbConfig> bookstoreDbConfig) 
        {
            var client = new MongoClient(bookstoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(bookstoreDbConfig.Value.Database_Name);
            _books = database.GetCollection<Book>(bookstoreDbConfig.Value.Books_Collection_Name);
        }
        public IMongoCollection<Book> GetBooksCollection() => _books;
    }
}
