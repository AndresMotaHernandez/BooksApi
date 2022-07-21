
using Bookstore.Core;
using MongoDB.Driver;

namespace BooksApi
{
    public interface IDbClient
    {
        IMongoCollection<Book> GetBooksCollection();
    }
}
