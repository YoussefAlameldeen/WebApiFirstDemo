using Microsoft.AspNetCore.Mvc;
using WebApiFirstDemo.ApplicationDbContext;
using WebApiFirstDemo.Dto;
using WebApiFirstDemo.Model;

namespace WebApiFirstDemo.Repositories.AuthorRepository
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly ApplicationDatabaseContext _context;

        public AuthorRepo(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        //public void AddAuthor(AuthorDto authorDto)
        //{
        //    Author A1 = new Author
        //    {
        //        AuthorName= authorDto.AuthorName,   
        //        AuthorEmail= authorDto.AuthorEmail, 
        //        PhoneNumber= authorDto.PhoneNumber, 
                
        //    };
        //    _context.Authors.Add(A1);
        //    _context.SaveChanges();
        //}

        public void AddAuthorBook(AuthorDto authorDto , string booktit)
        {
            var book = _context.Books.FirstOrDefault(i => i.BookTitle == booktit);
            if(book != null)
            {
                throw new Exception("This Book is added Before");
            }
            Author newAuthor = new Author
            {
                AuthorName = authorDto.AuthorName,
                AuthorEmail = authorDto.AuthorEmail,
                PhoneNumber = authorDto.PhoneNumber,
                Book = authorDto.BookDtos.Select(i => new Book
                {
                    BookTitle = i.BookTitle,
                    DateTime = DateTime.Now,
                }).ToList()
            };

            _context.Authors.Add(newAuthor);
            _context.SaveChanges();
        }
    }
}
