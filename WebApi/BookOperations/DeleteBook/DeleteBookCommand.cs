using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.DeleteBook
{  
    public class DeleteBookCommand
    {
        public DeleteBookViewModel Model { get; set; } 
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(){
            var book = _dbContext.Books .SingleOrDefault(x=>x.Id == BookId);
            if(book is null)
                throw new InvalidOperationException("Silinecek kitap bulunamadı.");
            _dbContext.Books.Remove(book);
        }
        public class DeleteBookViewModel{

        }
    }
}