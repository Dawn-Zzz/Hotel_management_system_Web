using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
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
            var phieuThues = db.PhieuThues.Include(p => p.KhachHang).OrderByDescending(p => p.HienTrang == "Chưa nhận phòng")
                    .ThenByDescending(p => p.HienTrang == "Đã nhận phòng");
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
                var listPhong = Session["listPhong"] as List<PhieuThuePhong>;
                if(listPhong == null)
                {
                    ModelState.AddModelError("CustomError", "Không thể nhận phòng vì chưa tới ngày nhận phòng!");
                    ViewBag.MaLoaiPhong = new SelectList(db.LoaiPhongs, "MaLoaiPhong", "TenLoaiPhong");
                    ViewBag.DSPhong = new SelectList(db.Phongs, "MaPhong", "MaPhong");
                    return View(phieuThue); 
                } 
                else {
                    foreach (var phong in listPhong)
                    {
                        var newPhieuThuePhong = new PhieuThuePhong
                        {
                            MaPhieu = phieuThue.MaPhieu,
                            MaPhong = phong.MaPhong,
                            SoNguoiO = phong.SoNguoiO
                        };

                        db.PhieuThuePhongs.Add(newPhieuThuePhong);
                    }

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            ViewBag.MaLoaiPhong = new SelectList(db.LoaiPhongs, "MaLoaiPhong", "TenLoaiPhong");
            ViewBag.DSPhong = new SelectList(db.Phongs, "MaPhong", "MaPhong");
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
            ViewBag.DichVu = new SelectList(db.DichVus, "MaDichVu", "TenDichVu");
            return View(phieuThue);
        }

        // POST: Admin/RegistrationForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int MaPhieu, string HienTrang)
        {
            PhieuThue phieuThue = db.PhieuThues.Find(MaPhieu);

            if (phieuThue == null)
            {
                return HttpNotFound();
            }
            if (HienTrang == "Đã nhận phòng")
            {
                if (phieuThue.ThoiGianNhanPhong > DateTime.Today)
                {
                    ModelState.AddModelError("CustomError", "Không thể nhận phòng vì chưa tới ngày nhận phòng!");
                    return View(phieuThue); // Trả về view để hiển thị thông báo lỗi
                }
            }
            if (HienTrang == "Đã trả phòng")
            {
                HoaDon hoaDon = phieuThue.HoaDons.FirstOrDefault();

                if (hoaDon != null)
                {
                    // Thực hiện các thao tác cần thiết với hoaDon
                    hoaDon.MaNhanVien = Convert.ToInt32(Session["MaNV"]);
                    db.HoaDons.Attach(hoaDon);
                    db.Entry(hoaDon).Property(x => x.MaNhanVien).IsModified = true;
                    db.SaveChanges();
                }
            }
            var listService = Session["listService"] as List<ChiTietHoaDonDichVu>;
            if (listService != null)
            {
                foreach (var service in listService)
                {
                    var newService = new ChiTietHoaDonDichVu
                    {
                        MaHoaDon = phieuThue.HoaDons.FirstOrDefault().MaHoaDon,
                        MaDichVu = service.MaDichVu,
                        SoLuong = service.SoLuong
                    };
                    db.ChiTietHoaDonDichVus.Add(newService);
                    db.SaveChanges();
                }
            }

            phieuThue.HienTrang = HienTrang;
            db.PhieuThues.Attach(phieuThue);
            db.Entry(phieuThue).Property(x => x.HienTrang).IsModified = true;

            db.SaveChanges();
            ViewBag.DichVu = new SelectList(db.DichVus, "MaDichVu", "TenDichVu");
            return RedirectToAction("Index");
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
            IQueryable<PhieuThue> query = db.PhieuThues;
            if (!string.IsNullOrEmpty(sdt))
            {
                query = query.Where(pt => pt.KhachHang.SoDienThoai.ToLower().Contains(sdt.ToLower()));
            }

            var ketqua = await query.ToListAsync();

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
            var room = listPhong.FirstOrDefault(s => s.MaPhong == maPhong);
            if (room != null)
            {
                listPhong.Remove(room);
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
            List<PhieuThuePhong> listPhong = Session["listPhong"] as List<PhieuThuePhong>;
            var availableRoomList = roomList.Except(bookedRoomList);
            if (listPhong != null)
                // Lọc danh sách phòng để chừa những phòng không có trong danh sách đã đặt
                availableRoomList = availableRoomList.Except(listPhong.Select(p => p.MaPhong)).ToList();
            else
                availableRoomList = availableRoomList.ToList();
            return Json(availableRoomList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMaPhongByIndex(int index)
        {
            List<PhieuThuePhong> listPhong = Session["listPhong"] as List<PhieuThuePhong>;

            if (listPhong != null && index >= 0 && index < listPhong.Count)
            {
                return Json(new { maPhong = listPhong[index].MaPhong }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { maPhong = "" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ResetListPhong()
        {
            Session["listPhong"] = null;
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult AddService(string maDichVu, byte soLuong)
        {
            // Lấy danh sách sách đã mượn từ Session hoặc tạo danh sách mới nếu chưa tồn tại
            List<ChiTietHoaDonDichVu> listService;

            if (Session["listService"] == null)
            {
                listService = new List<ChiTietHoaDonDichVu>();
            }
            else
            {
                listService = (List<ChiTietHoaDonDichVu>)Session["listService"];
            }

            // Tìm xem sách có MaSach trong danh sách chưa
            var existingService = listService.FirstOrDefault(s => s.MaDichVu == maDichVu);

            if (existingService != null)
            {
                // Nếu đã tồn tại, tăng số lượng
                existingService.SoLuong += soLuong;
            }
            else
            {
                // Nếu chưa tồn tại, thêm sách mới vào danh sách
                var newService = new ChiTietHoaDonDichVu
                {
                    MaDichVu = maDichVu,
                    SoLuong = soLuong
                };

                listService.Add(newService);
            }

            // Lưu danh sách đã cập nhật vào Session
            Session["listService"] = listService;

            // Trả về một JsonResult chứa danh sách sách đã cập nhật
            return Json(listService);
        }

        public ActionResult GetMaDichVuByIndex(int index)
        {
            List<ChiTietHoaDonDichVu> listService = Session["listService"] as List<ChiTietHoaDonDichVu>;

            if (listService != null && index >= 0 && index < listService.Count)
            {
                return Json(new { maDichVu = listService[index].MaDichVu }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { maDichVu = "" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteService(string maDichVu)
        {
            // Lấy danh sách sách đã mượn từ Session hoặc tạo danh sách mới nếu chưa tồn tại
            List<ChiTietHoaDonDichVu> listService = Session["listService"] as List<ChiTietHoaDonDichVu> ?? new List<ChiTietHoaDonDichVu>();

            // Tìm và xóa sách khỏi danh sách dựa trên mã sách
            var service = listService.FirstOrDefault(s => s.MaDichVu == maDichVu);
            if (service != null)
            {
                listService.Remove(service);
                Session["listService"] = listService;
                return Json(new { success = true, data = listService });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult ResetListService()
        {
            Session["listService"] = null;
            return Json(new { success = true });
        }
    }
}