using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZombieParty.Models;
using ZombieParty.Models.Data;

namespace ZombieParty.Controllers
{
    public class ZombieController : Controller
    {
        private ZombiePartyDbContext _baseDonnees { get; set; }

        public ZombieController(ZombiePartyDbContext baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        public IActionResult Index()
        {
           List<Zombie> zombieList = _baseDonnees.Zombie.ToList();

            return View(zombieList);
        }

        public IActionResult Create()
        {
            ZombieVM zombieVM = new ZombieVM();
            zombieVM.ZombieTypeSelectList = _baseDonnees.zombieType.Select(t => new SelectListItem
            {
                Text = t.TypeName,
                Value = t.Id.ToString()
            }).OrderBy(t => t.Text);

            return View(zombieVM);

        }

        [HttpPost]
        public IActionResult Create(ZombieVM zombievm)
        {
            //Si le modèle est valide le zombie est ajouté et nous sommes redirigé vers index.
            if (ModelState.IsValid)
            {
                _baseDonnees.Zombie.Add(zombievm.Zombie);
                _baseDonnees.SaveChanges();
                TempData["Success"] = $"Zombie {zombievm.Zombie.Name} added";
                return this.RedirectToAction("Index");
            }
            zombievm.ZombieTypeSelectList = _baseDonnees.zombieType.Select(t => new SelectListItem
            {
                Text = t.TypeName,
                Value = t.Id.ToString()
            }).OrderBy(t => t.Text);


            return View(zombievm);
        }

    }
}
