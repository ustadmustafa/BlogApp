namespace BlogApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        ICollection<Blog> BlogPosts { get; set; }

    }
}
