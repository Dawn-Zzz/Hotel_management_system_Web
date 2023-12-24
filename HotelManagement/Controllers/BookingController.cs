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
    public class BookingController : Controller
    {
        private Hotel_ManagementEntities db = new Hotel_ManagementEntities();

        // GET: Booking
        public ActionResult Index()
        {
            return View(db.LoaiPhongs.ToList());
        }

        // GET: Booking/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhong loaiPhong = db.LoaiPhongs.Find(id);
            if (loaiPhong == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhong);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiPhong,TenLoaiPhong,GiaLoaiPhong,HinhAnh")] LoaiPhong loaiPhong)
        {
            if (ModelState.IsValid)
            {
                db.LoaiPhongs.Add(loaiPhong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiPhong);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhong loaiPhong = db.LoaiPhongs.Find(id);
            if (loaiPhong == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhong);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiPhong,TenLoaiPhong,GiaLoaiPhong,HinhAnh")] LoaiPhong loaiPhong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiPhong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiPhong);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhong loaiPhong = db.LoaiPhongs.Find(id);
            if (loaiPhong == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhong);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiPhong loaiPhong = db.LoaiPhongs.Find(id);
            db.LoaiPhongs.Remove(loaiPhong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BookingRoom()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult GetRoomsByRoomTypeID(string maLoaiPhong, DateTime? checkIn, DateTime? checkOut)
        {
            // Lấy danh sách các phòng thuộc loại phòng maLoaiPhong và không trùng với ngày check-in và check-out
            var roomList = db.Phongs.Where(p => p.MaLoaiPhong == maLoaiPhong).Select(p => p.MaPhong).ToList();
            var bookedRoomList = db.PhieuThuePhongs
    .Where(pt => pt.PhieuThue.ThoiGianNhanPhong.HasValue && pt.PhieuThue.ThoiGianTraPhong.HasValue && (pt.PhieuThue.HienTrang == "Chưa nhận phòng" || pt.PhieuThue.HienTrang == "Đã nhận phòng") &&
                  !(checkIn >= pt.PhieuThue.ThoiGianTraPhong || checkOut <= pt.PhieuThue.ThoiGianNhanPhong))
    .Select(pt => pt.MaPhong)
    .ToList();
            List<PhieuThuePhong> listPhong = Session["listPhong"] as List<PhieuThuePhong>;
            var availableRoomList = roomList.Except(bookedRoomList);
            if (listPhong != null)
                // Lọc danh sách phòng để chừa những phòng không có trong danh sách đã đặt
                availableRoomList = availableRoomList.Except(listPhong.Select(p => p.MaPhong)).ToList();
            else
                availableRoomList = availableRoomList.ToList();
            return Json(availableRoomList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddBookRoom(string maLoaiPhong,List<string> phongs)
        {
            // Lấy danh sách sách đã mượn từ Session hoặc tạo danh sách mới nếu chưa tồn tại
            List<Phong> listPhong;

            if (Session["listPhong"] == null)
            {
                listPhong = new List<Phong>();
            }
            else
            {
                listPhong = (List<Phong>)Session["listPhong"];
            }
            if (phongs != null)
                foreach (var phong in phongs)
                {
                    // Tạo một phòng mới để thêm vào danh sách
                    var phongMoi = new Phong
                    {
                        MaLoaiPhong = maLoaiPhong,
                        MaPhong = phong.ToString()
                    };

                    // Thêm phòng mới vào danh sách
                    listPhong.Add(phongMoi);
                }
            // Sắp xếp danh sách theo MaLoaiPhong
            listPhong = listPhong.OrderBy(p => p.MaLoaiPhong).ToList();
            // Lưu danh sách đã cập nhật vào Session
            Session["listPhong"] = listPhong;

            // Trả về một JsonResult chứa danh sách sách đã cập nhật
            return Json(listPhong);
        }

        [HttpPost]
        public ActionResult DeleteBookRoom(string maLoaiPhong)
        {
            // Lấy danh sách sách đã mượn từ Session hoặc tạo danh sách mới nếu chưa tồn tại
            List<Phong> listPhong = Session["listPhong"] as List<Phong> ?? new List<Phong>();

            // Xóa tất cả các phần tử của listPhong có MaLoaiPhong bằng maLoaiPhong
            listPhong.RemoveAll(s => s.MaLoaiPhong == maLoaiPhong);

            // Lưu danh sách đã cập nhật vào Session
            Session["listPhong"] = listPhong;

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult ResetListPhong()
        {
            Session["listPhong"] = null;
            return Json(new { success = true });
        }
    }
}
