using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZombieParty.Models
{
    public class Zombie
    {
        [Key]
        public int Id { get; set; }
        [Range(5,20 , ErrorMessage = "{0} requires a value between {5} and {20}.")]
        public string Name { get; set; }

        [Display(Name = "Zombie Type")]
        [ForeignKey("ZombieType")]
        public int ZombieTypeId { get; set; }
       

        public ZombieType? ZombieType { get; set; }
        [Range(1, 10, ErrorMessage = "{0} requires a value between {1} and {10}.")]

        public int Point { get; set; }
        [Range(0, 225, ErrorMessage = "{0} requires a value between {0} and {255}.")]

        public String Shortdesc { get; set; }
    }
}
