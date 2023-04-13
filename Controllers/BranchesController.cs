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
    public class BranchesController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Branches
        public ActionResult Index()
        {
            return View(db.Branchs.ToList());
        }

        // GET: Branches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branchs.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // GET: Branches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Address,PhoneNumber")] Branch branch)
        {
            if (checkIfEmailAlreadyExists(branch.Email, branch.ID))
            {
                ModelState.AddModelError("", "Esse e-mail já possui cadastro no sistema.");
                return View(branch);
            }

            if (checkIfPhoneNumberAlreadyExists(branch.PhoneNumber, branch.ID))
            {
                ModelState.AddModelError("", "Esse número de telefone já possui cadastro no sistema.");
                return View(branch);
            }

            if (ModelState.IsValid)
            {
                db.Branchs.Add(branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(branch);
        }

        // GET: Branches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branchs.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Address,PhoneNumber")] Branch branch)
        {

            if (checkIfEmailAlreadyExists(branch.Email, branch.ID))
            {
                ModelState.AddModelError("", "Esse e-mail já possui cadastro no sistema.");
                return View(branch);
            }

            if (checkIfPhoneNumberAlreadyExists(branch.PhoneNumber, branch.ID))
            {
                ModelState.AddModelError("", "Esse número de telefone já possui cadastro no sistema.");
                return View(branch);
            }

            if (ModelState.IsValid)
            {
                db.Branchs.AddOrUpdate(branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        // GET: Branches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branchs.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Branch branch = db.Branchs.Find(id);
            db.Branchs.Remove(branch);
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
