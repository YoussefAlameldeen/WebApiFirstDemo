namespace WebApiFirstDemo.Model
{
    public class Book
    {
        public int BookId {  get; set; }    
        public string BookTitle { get; set; }   
        public DateTime DateTime { get; set; }
        public List<Author> Author {  get; set; }   

    }
}
