using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (string.IsNullOrEmpty(authorDto.AuthorEmail))
            {
                throw new ArgumentException("Email is required", nameof(authorDto.AuthorEmail));
            }


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
        public AuthorDto GetAuthorBookByName(string authorName)
        {
            var auth = _context.Authors
                .Include(a => a.Book) 
                .Where(a => a.AuthorName == authorName)
                .Select(a => new AuthorDto
                {
                    AuthorName = a.AuthorName,
                    BookDtos = a.Book.Select(b => new BookDto
                    {
                        BookTitle = b.BookTitle,
                    }).ToList()
                })
                .FirstOrDefault();

            return auth;
        }

        public void UpdateAuthor(AuthorDto authordto , string authname) //match by id for uniquness
        {
            var auth = _context.Authors.Include(i=>i.Book).FirstOrDefault(i => i.AuthorName == authname);
            auth.AuthorName= authordto.AuthorName;

            auth.Book = authordto.BookDtos.Select(i => new Book
            {
                BookTitle = i.BookTitle,
            }).ToList();
            _context.Authors.Update(auth);
           
            _context.SaveChanges();
        }

    }
}
