using System.ComponentModel;

namespace BlogApp.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Category { get; set; }
        public string PublishDate { get; set; }
        
    }
}
