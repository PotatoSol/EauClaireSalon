using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        private readonly HairSalonContext _db;

        public ClientsController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Client> model = _db.Clients
                                .Include(Client => Client.PersonalStylist)
                                .ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client aClient)
        {
            if (aClient.StylistId == 0)
            {
                return RedirectToAction("Create");
            }
            _db.Clients.Add(aClient);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Client thisClient = _db.Clients
                                .Include(Client => Client.PersonalStylist)
                                .FirstOrDefault(Client => Client.ClientId == id);
            return View(thisClient);
        }

        public ActionResult Edit(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(Client => Client.ClientId == id);
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
            return View(thisClient);
        }

        [HttpPost]
        public ActionResult Edit(Client Client)
        {
            _db.Clients.Update(Client);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(Client => Client.ClientId == id);
            return View(thisClient);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client thisClient = _db.Clients.FirstOrDefault(Client => Client.ClientId == id);
            _db.Clients.Remove(thisClient);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}