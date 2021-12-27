using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=>x.Id == AuthorId);
            var book = _context.Books.Any(x=>x.AuthorId==AuthorId);

            if(author is null)
                throw new InvalidOperationException("Silinecek yazar bulunamadı.");
            if(book)
                throw new InvalidOperationException("Kitabı yayında olan bir yazar silinemez.");
            _context.Remove(author);
            _context.SaveChanges();
        }
    }
}