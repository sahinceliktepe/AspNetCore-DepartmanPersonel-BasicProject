using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDepartman.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreDepartman.Controllers
{
    public class DepartController : Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var degerler = c.Departmanlars.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniDepartman()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniDepartman(Departmanlar d)
        {
            c.Departmanlars.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DepartmanSil(int id)
        {
            var dep = c.Departmanlars.Find(id);
            c.Departmanlars.Remove(dep);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DepartmanGetir(int id)
        {
            var depart = c.Departmanlars.Find(id);
            return View("DepartmanGetir",depart);
        }

        public IActionResult DepartmanGuncelle(Departmanlar d)
        {
            var dep = c.Departmanlars.Find(d.Id);
            dep.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Depart.Id == id).ToList();
            var departmanAd = c.Departmanlars.Where(x => x.Id == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.dprtAd = departmanAd;
            return View(degerler);
        }
    }
}
