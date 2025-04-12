namespace BlogApp.Models
{
    
    public class BlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PublishDate { get; set; }
        public string AuthorName { get; set; }  // User tablosundan
        public string CategoryName { get; set; } // Category tablosundan
    }
}
