using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WepApi.DBOperations
{
    
    public class DataGenerator{
        //verileri insert eden method: inmemory service provider ile program.cs ye bağlanır. 
        //program.cs deki serviceprovider burayı çağıracak.uygulama ilk ayağa kalktığında hep çalışacak.
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // context instance 
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any()){
                    //hiç kitap var mı?
                    return;//çalıştırma
                } 

                context.Authors.AddRange(
                    new Author{
                        Name ="Joanne Kathleen",
                        Surname ="Rowling",
                        Birthday = new DateTime(1965,07,31)
                    },
                    new Author{
                        Name ="Jean-Jacques",
                        Surname ="Rousseau",
                        Birthday = new DateTime(1712,06,28)
                    },
                    new Author{
                        Name ="Charlotte Perkins",
                        Surname ="Gilman",
                        Birthday = new DateTime(1860,07,03)
                    }
                );

                context.Genres.AddRange(
                    new Genre{
                        Name ="Personal Growth"
                    },
                    new Genre{
                        Name="Science Fiction"
                    },
                    new Genre{
                        Name="Novel"
                    }
                );
                context.Books.AddRange(   //Books içine 2 tane kitap eklendi.
                    new Book{
                       // Id = 1,
                        Title = "Harry Potter and the Philosopher's Stone",
                        GenreId = 3,
                        PageCount =220,
                        PublishDate =new DateTime(1997,02,12),
                        AuthorId= 1
                    },
                    new Book{
                       // Id = 2,
                        Title = "herland",
                        GenreId = 2,
                        PageCount =250,
                        PublishDate =new DateTime(1915,04,1),
                        AuthorId=3
                    }
                );//database de değişiklik yapınca onu savechanges diyerek kaydetmemiz gerekir.
                context.SaveChanges();        
            }
        }
    }
}