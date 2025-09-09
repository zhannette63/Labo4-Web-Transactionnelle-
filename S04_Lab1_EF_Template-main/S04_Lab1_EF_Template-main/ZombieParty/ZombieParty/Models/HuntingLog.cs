using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class HuntingLog
    {
        [Key]
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }


    }
}
