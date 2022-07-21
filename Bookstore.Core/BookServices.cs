using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using BooksApi;

namespace Bookstore.Core
{
    public class BookServices : IBookServices
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    id = 1,
                    title = "Bajo el sol",
                    description = "Prueba",
                    excerpt  = "Prueba Amplia",
                    pageCount = 150,
                    publishDate = "5/11/2018"
                }
            };
        }
    }
}
