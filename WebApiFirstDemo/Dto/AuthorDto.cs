using System.ComponentModel.DataAnnotations;
using WebApiFirstDemo.Model;

namespace WebApiFirstDemo.Dto
{
    public class AuthorDto
    {
        [Required]
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public List<BookDto> BookDtos { get; set; }
    }
}
