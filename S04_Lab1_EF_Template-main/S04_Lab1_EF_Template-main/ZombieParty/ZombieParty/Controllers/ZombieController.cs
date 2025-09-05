﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZombieParty.Models;

namespace ZombieParty.Controllers
{
    public class ZombieController : Controller
    {
        private BaseDonnees _baseDonnees { get; set; }

        public ZombieController(BaseDonnees baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        public IActionResult Index()
        {
            this.ViewBag.MaListe = _baseDonnees.Zombies.ToList();

            return View();
        }

        public IActionResult Create()
        {
            ViewBag.ZombieTypes = new SelectList(_baseDonnees.ZombieTypes.ToList(), "Id", "TypeName", null);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Zombie zombie)
        {
            //Si le modèle est valide le zombie est ajouté et nous sommes redirigé vers index.
            if (ModelState.IsValid)
            {
                _baseDonnees.Zombies.Add(zombie);
                TempData["Success"] = $"Zombie {zombie.Name} added";
                return this.RedirectToAction("Index");
            }
            //Il faut repopuler le zombieType dans le ViewBag
            //Aller chercher le ZombieType sélectionné, rappel 2W5 Linq
            ZombieType selectedZombieType = _baseDonnees.ZombieTypes.Where(zt => zt.Id == zombie.ZombieTypeId).SingleOrDefault();
            zombie.ZombieType = selectedZombieType;

            ViewBag.ZombieTypes = new SelectList(_baseDonnees.ZombieTypes.ToList(), "Id", "TypeName", selectedZombieType);

            return View(zombie);
        }

    }
}
