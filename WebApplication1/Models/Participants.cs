using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Participants
    {
        [Key]
        public int Id { get; set; }

        public int Host { get; set; }

        [DisplayName("Име")]
        public String Name { get; set; }

        [DisplayName("e-mail")]
        public String email { get; set; }

        [DisplayName("Порака")]
        public String message { get; set; }

        public int? buysTO { get; set; }
        public int? receiveFrom { get; set; }
        public Participants() { }
        public Participants(String name, String email, String message, int Host)
        {
            this.email = email;
            this.message = message;
            this.Name = name;
            this.Host = Host;
        }
        public Participants(String name, String email, int Host)
        {
            this.email = email;
            this.message = "Домаќин";
            this.Name = name;
            this.Host = Host;
        }
    }
}
