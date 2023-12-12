﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagement;

namespace HotelManagement.Areas.Admin.Controllers
{
    public class RegistrationFormController : Controller
    {
        private Hotel_ManagementEntities db = new Hotel_ManagementEntities();

        // GET: Admin/RegistrationForm
        public ActionResult Index()
        {
            var phieuThues = db.PhieuThues.Include(p => p.KhachHang).Include(p => p.NhanVien);
            return View(phieuThues.ToList());
        }

        // GET: Admin/RegistrationForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThue phieuThue = db.PhieuThues.Find(id);
            if (phieuThue == null)
            {
                return HttpNotFound();
            }
            return View(phieuThue);
        }

        // GET: Admin/RegistrationForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RegistrationForm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieu,NgayLap,ThoiGianNhanPhong,ThoiGianTraPhong,HienTrang,MaKhachHang,MaNhanVien")] PhieuThue phieuThue)
        {
            if (ModelState.IsValid)
            {
                db.PhieuThues.Add(phieuThue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phieuThue);
        }

        // GET: Admin/RegistrationForm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThue phieuThue = db.PhieuThues.Find(id);
            if (phieuThue == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "CCCD", phieuThue.MaKhachHang);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "CCCD", phieuThue.MaNhanVien);
            return View(phieuThue);
        }

        // POST: Admin/RegistrationForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieu,NgayLap,ThoiGianNhanPhong,ThoiGianTraPhong,HienTrang,MaKhachHang,MaNhanVien")] PhieuThue phieuThue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuThue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "CCCD", phieuThue.MaKhachHang);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "CCCD", phieuThue.MaNhanVien);
            return View(phieuThue);
        }

        // GET: Admin/RegistrationForm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThue phieuThue = db.PhieuThues.Find(id);
            if (phieuThue == null)
            {
                return HttpNotFound();
            }
            return View(phieuThue);
        }

        // POST: Admin/RegistrationForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuThue phieuThue = db.PhieuThues.Find(id);
            db.PhieuThues.Remove(phieuThue);
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