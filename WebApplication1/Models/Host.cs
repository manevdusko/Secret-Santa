using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Host
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Име")]
        public String Name { get; set; }

        [DisplayName("e-mail")]
        public String email { get; set; }
        public Host() { }
        public Host(String name, String email, String message)
        {
            this.email = email;
            this.Name = name;
        }
    }
}
