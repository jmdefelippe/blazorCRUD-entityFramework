using BlazorCRUDEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCRUDEntityFramework.Data
{
    public class BookService : IBookService
    {
        private readonly MyBooksContext _context;

        public BookService(MyBooksContext context) {
            _context = context;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookDetails(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<bool> InsertBook(Book book)
        {
            _context.Books.Add(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveBook(Book book)
        {
            if (book.BookId > 0)
            {
                return await UpdateBook(book);
            }
            else 
            {
                return await InsertBook(book);
            }
        }
    }
}
