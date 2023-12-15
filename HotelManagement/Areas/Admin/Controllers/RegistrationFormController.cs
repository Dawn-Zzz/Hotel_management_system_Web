using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            var phieuThues = db.PhieuThues.Include(p => p.KhachHang);
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
            ViewBag.MaLoaiPhong = new SelectList(db.LoaiPhongs, "MaLoaiPhong", "TenLoaiPhong");
            ViewBag.DSPhong = new SelectList(db.Phongs, "MaPhong", "MaPhong");
            ViewBag.DichVu = new SelectList(db.DichVus, "MaDichVu", "TenDichVu");
            return View();
        }

        // POST: Admin/RegistrationForm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieu,NgayLap,ThoiGianNhanPhong,ThoiGianTraPhong,HienTrang,MaKhachHang")] PhieuThue phieuThue, string phoneNumber)
        {
            if (ModelState.IsValid)
            {
                phieuThue.NgayLap = DateTime.Now.Date;
                phieuThue.MaKhachHang = db.KhachHangs.Where(kh => kh.SoDienThoai == phoneNumber).Select(kh => kh.MaKhachHang).FirstOrDefault();
                phieuThue.HienTrang = "Chưa nhận phòng";
                
                db.PhieuThues.Add(phieuThue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiPhong = new SelectList(db.LoaiPhongs, "MaLoaiPhong", "TenLoaiPhong");
            ViewBag.DSPhong = new SelectList(db.Phongs, "MaPhong", "MaPhong");
            ViewBag.DichVu = new SelectList(db.DichVus, "MaDichVu", "TenDichVu");
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "CCCD", phieuThue.MaKhachHang);
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
            
            return View(phieuThue);
        }

        // POST: Admin/RegistrationForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieu,NgayLap,ThoiGianNhanPhong,ThoiGianTraPhong,HienTrang,MaKhachHang")] PhieuThue phieuThue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuThue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "CCCD", phieuThue.MaKhachHang);
            
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

        [Route("Search")]
        public async Task<ActionResult> Search(string sdt)
        {
            var ketqua = await db.PhieuThues.Where(pt => pt.KhachHang.SoDienThoai.ToLower().Contains(sdt.ToLower())).ToListAsync();

            return View("Index", ketqua);
        }

        [HttpPost]
        public ActionResult AddBookRoom(string maPhong, byte soNguoiO)
        {
            // Lấy danh sách sách đã mượn từ Session hoặc tạo danh sách mới nếu chưa tồn tại
            List<PhieuThuePhong> listPhong; 
            
            if (Session["listPhong"] == null)
            {
                listPhong = new List<PhieuThuePhong>();
            }
            else
            {
                listPhong = (List<PhieuThuePhong>)Session["listPhong"];
            }
           
            // Nếu chưa tồn tại, thêm sách mới vào danh sách
            var phongMoi = new PhieuThuePhong
            {
                MaPhong = maPhong,
                SoNguoiO = soNguoiO  
            };

            listPhong.Add(phongMoi);
            // Lưu danh sách đã cập nhật vào Session
            Session["listPhong"] = listPhong;

            // Trả về một JsonResult chứa danh sách sách đã cập nhật
            return Json(listPhong);
        }

        [HttpPost]
        public ActionResult DeleteBookRoom(string maPhong)
        {
            // Lấy danh sách sách đã mượn từ Session hoặc tạo danh sách mới nếu chưa tồn tại
            List<PhieuThuePhong> listPhong = Session["listPhong"] as List<PhieuThuePhong> ?? new List<PhieuThuePhong>();

            // Tìm và xóa sách khỏi danh sách dựa trên mã sách
            var sachXoa = listPhong.FirstOrDefault(s => s.MaPhong == maPhong);
            if (sachXoa != null)
            {
                listPhong.Remove(sachXoa);
                Session["listPhong"] = listPhong;
                return Json(new { success = true });
            }

            return Json(new { success = false });
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
            var availableRoomList = roomList.Except(bookedRoomList).ToList();
            return Json(availableRoomList, JsonRequestBehavior.AllowGet);
        }
    }
}
