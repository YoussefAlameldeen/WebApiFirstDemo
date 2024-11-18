using WebApiFirstDemo.Dto;

namespace WebApiFirstDemo.Repositories.AuthorRepository
{
    public interface IAuthorRepo
    {
        //public void AddAuthor(AuthorDto authorDto);
        public void AddAuthorBook(AuthorDto authorDto,string bookkit);
        public void UpdateAuthor(AuthorDto authordto, string authname);

    }
}
