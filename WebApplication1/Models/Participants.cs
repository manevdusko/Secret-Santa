using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Participants
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Име")]
        public String Name { get; set; }

        [DisplayName("e-mail")]
        public String email { get; set; }

        [DisplayName("Порака")]
        public String message { get; set; }
        public Participants() { }
        public Participants(String name, String email, String message)
        {
            this.email = email;
            this.message = message;
            this.Name = name;
        }
    }
}
