using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HotelManagement;

namespace HotelManagement.Areas.Admin.Controllers
{
    public class GuestController : Controller
    {
        private Hotel_ManagementEntities db = new Hotel_ManagementEntities();

        // GET: Admin/Guest
        public ActionResult Index()
        {
            var khachHangs = db.KhachHangs.Include(k => k.TaiKhoanKHs);
            return View(khachHangs.ToList());
        }

        // GET: Admin/Guest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: Admin/Guest/Create
        public ActionResult Create()
        {
            ViewBag.LoaiKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "LoaiKhachHang");
            return View();
        }

        // POST: Admin/Guest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhachHang,CCCD,TenKhachHang,LoaiKhachHang,SoDienThoai,NgaySinh")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                var existingCustomerCCCD = db.KhachHangs.FirstOrDefault(k => k.CCCD == khachHang.CCCD);
                var existingCustomerPhone = db.KhachHangs.FirstOrDefault(k => k.SoDienThoai == khachHang.SoDienThoai);

                if (existingCustomerCCCD != null)
                {
                    ModelState.AddModelError("CCCD", "CCCD đã tồn tại.");
                }

                if (existingCustomerPhone != null)
                {
                    ModelState.AddModelError("SoDienThoai", "Số điện thoại đã tồn tại.");
                }

                // Nếu có lỗi, trả về View với ModelState chứa thông báo lỗi
                if (ModelState.IsValid == false)
                {
                    return View(khachHang);
                }



                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.LoaiKhachHang = new SelectList(db.TaiKhoanKHs, "MaKhachHang", "LoaiKhachHang", khachHang.LoaiKhachHang);
            return View(khachHang);
        }

        // GET: Admin/Guest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            //ViewBag.TenTaiKhoan = new SelectList(db.TaiKhoanKHs, "TenTaiKhoan", "MatKhau", khachHang.TenTaiKhoan);

            return View(khachHang);
        }

        // POST: Admin/Guest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhachHang,CCCD,TenKhachHang,LoaiKhachHang,NgaySinh,SoDienThoai")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.TenTaiKhoan = new SelectList(db.TaiKhoanKHs, "TenTaiKhoan", "MatKhau", khachHang.TenTaiKhoan);
            return View(khachHang);
        }

        // GET: Admin/Guest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/Guest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
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

        [Route("Search")]
        public async Task<ActionResult> Search(string name)
        {
            IQueryable<KhachHang> query = db.KhachHangs;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(kh => kh.TenKhachHang.ToLower().Contains(name.ToLower()));
            }

            var ketqua = await query.ToListAsync();

            return View("Index", ketqua);
        }
    }
}
