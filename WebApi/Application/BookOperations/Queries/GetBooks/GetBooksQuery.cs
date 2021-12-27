using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery{
        //sadece constructor içerisinden set edilsin.
        private readonly BookStoreDbContext  _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            //DBCONTEXT İHTİYACIM VAR
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle(){// İSTEDİĞİM VERİ TİPİNİN UI dönmesini istiyorum. O yüzden aşağıda viewmodel kuralım.
            var bookList = _dbContext.Books.Include(x=>x.Genre).Include(x=>x.Author).OrderBy(x=>x.Id).ToList<Entities.Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);//new List<BooksViewModel>();
            return vm;
        }

    }
    public class BooksViewModel{
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
       
    }
}