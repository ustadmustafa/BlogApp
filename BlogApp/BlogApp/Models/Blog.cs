using System.ComponentModel;

namespace BlogApp.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //public User User { get; set; }
        public string PublishDate { get; set; }
        //public Category Category { get; set; }
        //string? ImgUrl { get; set; } 
    }
}
