using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public UpdateAuthorViewModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=>x.Id == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Güncellenecek yazar bulunamadı.");
            author.Name = Model.Name != default ? Model.Name : author.Name; 
            author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
            author.Birthday = Model.Birthday != default ? Model.Birthday : author.Birthday;           
            _context.SaveChanges();
        }
    }
    public class UpdateAuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }
}