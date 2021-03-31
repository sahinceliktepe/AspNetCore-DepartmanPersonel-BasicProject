using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDepartman.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CoreDepartman.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var degerler = c.Personels.Include(x => x.Depart).ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from x in c.Departmanlars.ToList() select new SelectListItem { Text = x.DepartmanAd, Value = x.Id.ToString() }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public IActionResult YeniPersonel(Personel p)
        {
            var per = c.Departmanlars.Where(x => x.Id == p.Depart.Id).FirstOrDefault();
            p.Depart = per;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
