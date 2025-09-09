﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ZombieParty.Models;
using ZombieParty.Models.Data;
using ZombieParty.ViewModels;


namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {
        private ZombiePartyDbContext _baseDonnees { get; set; }

        public ZombieTypeController(ZombiePartyDbContext baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        public IActionResult Index()
        {
            List<ZombieType> zombieTypesList = _baseDonnees.zombieType.ToList();

            return View(zombieTypesList);
        }

        public IActionResult Details(int id)
        {
            var zombies = _baseDonnees.Zombie.Where(z => z.ZombieTypeId == id);

            ZombieTypeVM zombieTypeVM = new()
            {
                ZombieType = new(),
                ZombiesList = zombies.ToList(),
                ZombiesCount = zombies.Count(),
                PointsAverage = zombies.Average(p => p.Point)
            };

            zombieTypeVM.ZombieType = _baseDonnees.zombieType.FirstOrDefault(zt => zt.Id == id);
            return View(zombieTypeVM);
        }


        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
     
        public IActionResult Create(Models.ZombieType zombieType)
        {
            if (ModelState.IsValid)
            {
                // Ajouter à la BD
                _baseDonnees.zombieType.Add(zombieType);
                TempData["Success"] = $"{zombieType.TypeName} zombie type added";
                return this.RedirectToAction("Index");
            }

            return this.View(zombieType);
        }

    }
}
