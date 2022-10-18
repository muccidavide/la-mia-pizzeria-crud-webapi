using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace la_mia_pizzeria_post.Models
{
    public class Message
    {
        public Message()
        {
        }

        public int Id { get; set; }
        [Required]
       
        public string Title { get; set; }
        [Required]
        
        public string Body { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
