using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using a1_hotel.Dal;
using a1_hotel.Models;

namespace a1_hotel.Controllers
{
    public class ClientsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Cpf,Email,PhoneNumber")] Client client)
        {
            if (checkIfEmailAlreadyExists(client.Email, 0))
            {
                ModelState.AddModelError("", "Esse e-mail já possui cadastro no sistema.");
                return View(client);
            }

            if (checkIfCpfAlreadyExists(client.Cpf, 0))
            {
                ModelState.AddModelError("", "Já existe um usuário registrado com esse CPF.");
                return View(client);
            }

            if (checkIfPhoneNumberAlreadyExists(client.PhoneNumber, 0))
            {
                ModelState.AddModelError("", "Esse número de telefone já possui cadastro no sistema.");
                return View(client);
            }

            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Cpf,Email,PhoneNumber")] Client client)
        {

            if (checkIfEmailAlreadyExists(client.Email, client.ID))
            {
                ModelState.AddModelError("", "Esse e-mail já possui cadastro no sistema.");
                return View(client);
            }

            if (checkIfCpfAlreadyExists(client.Cpf, client.ID))
            {
                ModelState.AddModelError("", "Já existe um usuário registrado com esse CPF.");
                return View(client);
            }

            if (checkIfPhoneNumberAlreadyExists(client.PhoneNumber, client.ID))
            {
                ModelState.AddModelError("", "Esse número de telefone já possui cadastro no sistema.");
                return View(client);
            }

            if (ModelState.IsValid)
            {
                db.Clients.AddOrUpdate(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool checkIfEmailAlreadyExists(string email, int id)
        {
            if (db.Clients.Any(c => c.Email == email))
            {
                Client clien = db.Clients.Where(c => c.Email == email).First();
                if (clien.ID != id) return true;
            }

            if (db.Branchs.Any(c => c.Email == email))
            {
                Branch branch = db.Branchs.Where(c => c.Email == email).First();
                if (branch.ID != id) return true;
            }

            return false;
        }

        public bool checkIfCpfAlreadyExists(string cpf, int id)
        {
            if (db.Clients.Any(c => c.Cpf == cpf))
            {
                Client clien = db.Clients.Where(c => c.Cpf == cpf).First();
                if (clien.ID != id) return true;
            }
            return false;
        }

        public bool checkIfPhoneNumberAlreadyExists(string phoneNumber, int id)
        {
            if (db.Clients.Any(c => c.PhoneNumber == phoneNumber))
            {
                Client clien = db.Clients.Where(c => c.PhoneNumber == phoneNumber).First();
                if (clien.ID != id) return true;
            }

            if (db.Branchs.Any(c => c.PhoneNumber == phoneNumber))
            {
                Branch branch = db.Branchs.Where(c => c.PhoneNumber == phoneNumber).First();
                if (branch.ID != id) return true;
            }
            return false;
        }
    }
}
