using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagement;

namespace HotelManagement.Controllers
{
    public class BookedRoomsController : Controller
    {
        private Hotel_ManagementEntities db = new Hotel_ManagementEntities();

        // GET: BookedRooms
        public ActionResult Index()
        {
            var chiTietThues = db.ChiTietThues.Include(c => c.PhieuDangKy).Include(c => c.Phong);
            return View(chiTietThues.ToList());
        }

        // GET: BookedRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietThue chiTietThue = db.ChiTietThues.Find(id);
            if (chiTietThue == null)
            {
                return HttpNotFound();
            }
            return View(chiTietThue);
        }

        // GET: BookedRooms/Create
        public ActionResult Create()
        {
            ViewBag.MaPhieu = new SelectList(db.PhieuDangKies, "MaPhieu", "HienTrang");
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "MaLoaiPhong");
            return View();
        }

        // POST: BookedRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieu,MaPhong,SoNguoiO")] ChiTietThue chiTietThue)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietThues.Add(chiTietThue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhieu = new SelectList(db.PhieuDangKies, "MaPhieu", "HienTrang", chiTietThue.MaPhieu);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "MaLoaiPhong", chiTietThue.MaPhong);
            return View(chiTietThue);
        }

        // GET: BookedRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietThue chiTietThue = db.ChiTietThues.Find(id);
            if (chiTietThue == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhieu = new SelectList(db.PhieuDangKies, "MaPhieu", "HienTrang", chiTietThue.MaPhieu);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "MaLoaiPhong", chiTietThue.MaPhong);
            return View(chiTietThue);
        }

        // POST: BookedRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieu,MaPhong,SoNguoiO")] ChiTietThue chiTietThue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietThue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhieu = new SelectList(db.PhieuDangKies, "MaPhieu", "HienTrang", chiTietThue.MaPhieu);
            ViewBag.MaPhong = new SelectList(db.Phongs, "MaPhong", "MaLoaiPhong", chiTietThue.MaPhong);
            return View(chiTietThue);
        }

        // GET: BookedRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietThue chiTietThue = db.ChiTietThues.Find(id);
            if (chiTietThue == null)
            {
                return HttpNotFound();
            }
            return View(chiTietThue);
        }

        // POST: BookedRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietThue chiTietThue = db.ChiTietThues.Find(id);
            db.ChiTietThues.Remove(chiTietThue);
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
