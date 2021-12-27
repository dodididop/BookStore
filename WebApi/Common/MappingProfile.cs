using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.GetAuthors;
using WebApi.Application.GenreOperations.Queries;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile{
        public MappingProfile(){
            CreateMap<CreateBookModel,Entities.Book>();
            CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name));
            CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Author, opt=>opt.MapFrom(src=>src.Author.Name));
            CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name));
            CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Author, opt=>opt.MapFrom(src=>src.Author.Name));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<Author,AuthorsViewModel>();
            CreateMap<Author,AuthorDetailViewModel>();
            CreateMap<CreateAuthorViewModel,Author>();
        }
    }
}