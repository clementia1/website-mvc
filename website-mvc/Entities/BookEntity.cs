using System.ComponentModel.DataAnnotations;

namespace website_mvc.Entities
{
    public class BookEntity
    {
        public string Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}