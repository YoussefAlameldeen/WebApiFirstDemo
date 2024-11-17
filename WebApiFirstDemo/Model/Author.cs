using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApiFirstDemo.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; }

        [EmailAddress]
        public string AuthorEmail {  get; set; }
        [Phone]
        public string PhoneNumber { get; set; }    
        public List<Book> Book { get; set; }
    }
}
