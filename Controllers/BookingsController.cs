using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using a1_hotel.Dal;
using a1_hotel.Models;

namespace a1_hotel.Controllers
{
    public class BookingsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Client).Include(b => b.Room);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Name");
            var AvailableRooms = db.Rooms.Where(r => r.Available == true);
            ViewBag.RoomID = new SelectList(AvailableRooms, "ID", "Name");
            
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EntryDate,DepartureDate,Guests,Price,ClientID,RoomID")] Booking booking)
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Name", booking.ClientID);
            var AvailableRooms = db.Rooms.Where(r => r.Available == true);
            ViewBag.RoomID = new SelectList(AvailableRooms, "ID", "Name", booking.RoomID);

            if (booking.DepartureDate <= booking.EntryDate)
            {
                ModelState.AddModelError("", "A data de saída deve ser posterior a data de entrada.");
                return View(booking);
            }

            if (booking.Price < 0 )
            {
                ModelState.AddModelError("", "O preço não pode ser negativo.");
                return View(booking);
            }

            if (booking.Guests > 5)
            {
                ModelState.AddModelError("", "Só é permitido a entrada de até 5 pessoas.");
                return View(booking);
            }

            if (booking.Guests < 0)
            {
                ModelState.AddModelError("", "Não é permitido a entrada de valor negativo para a Quantidade de Convidados");
                return View(booking);
            }

            if (ModelState.IsValid)
            {
                booking.Status = BookingStatus.Pendente;
                db.Payments.Add(new Payment(booking: booking));
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Name", booking.ClientID);
            var AvailableRooms = db.Rooms.Where(r => r.Available == true);
            ViewBag.RoomID = new SelectList(AvailableRooms, "ID", "Name", booking.RoomID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EntryDate,DepartureDate,Guests,Status,Price,ClientID,RoomID")] Booking booking)
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ID", "Name", booking.ClientID);
            var AvailableRooms = db.Rooms.Where(r => r.Available == true);
            ViewBag.RoomID = new SelectList(AvailableRooms, "ID", "Name", booking.RoomID);

            if (booking.DepartureDate <= booking.EntryDate)
            {
                ModelState.AddModelError("", "A data de saída deve ser posterior a data de entrada.");
                return View(booking);
            }

            if (booking.Price < 0)
            {
                ModelState.AddModelError("", "O preço não pode ser negativo.");
                return View(booking);
            }

            if (ModelState.IsValid)
            {
                Payment payment = db.Payments.Where(p => p.BookingID == booking.ID).First();
                if (booking.Status == BookingStatus.Cancelado)
                {
                    payment.PaymentStatus = PaymentStatus.Negado;
                    payment.PaymentDate = null;
                    db.Entry(booking).State = EntityState.Modified;
                } else if (booking.Status == BookingStatus.Aprovado)
                {
                    payment.PaymentStatus = PaymentStatus.Aprovado;
                    payment.PaymentDate = DateTime.Now;
                    db.Entry(booking).State = EntityState.Modified;
                } else if (booking.Status == BookingStatus.Pendente)
                {
                    payment.PaymentStatus = PaymentStatus.Aguardando;
                    payment.PaymentDate = null;
                    db.Entry(booking).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
    }
}
