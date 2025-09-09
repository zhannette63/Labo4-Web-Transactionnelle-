using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZombieParty.Models
{
    public class ZombieVM
    {
        public Zombie Zombie { get; set; }

        public IEnumerable<SelectListItem>? ZombieTypeSelectList { get; set; }

    }
}
