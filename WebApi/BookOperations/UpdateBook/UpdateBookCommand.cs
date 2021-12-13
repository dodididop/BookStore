using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.GetBooks;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookViewModel Model { get; set; }
        
        public int BookId{get;set;}
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(){
            var book = _dbContext.Books.SingleOrDefault(x=>x.Id == BookId);
            if(book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            _dbContext.SaveChanges();
        }
    }

    public class UpdateBookViewModel{
        public string Title { get; set; }
        public int GenreId { get; set; }
    }

}