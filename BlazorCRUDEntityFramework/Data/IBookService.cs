using BlazorCRUDEntityFramework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCRUDEntityFramework.Data
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookDetails(int id);
        Task<bool> InsertBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);

        Task<bool> SaveBook(Book book);
    }
}
