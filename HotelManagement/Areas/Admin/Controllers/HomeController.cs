using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        Hotel_ManagementEntities db = new Hotel_ManagementEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var totalRooms = db.Phongs.Count();
            var totalEmployees = db.NhanViens.Count();
            var totalBookings = db.PhieuThuePhongs.Count();
            var totalRoomBookings = db.Phongs.Count(p => p.HienTrang == true);
            var totalRevenue = db.HoaDons.Sum(h => h.TienPhong + (h.TienDichVu ?? 0));
            string formattedNumber = totalRevenue.ToString("#,##0");

            ViewBag.TotalRooms = totalRooms;
            ViewBag.TotalEmployees = totalEmployees;
            ViewBag.TotalBookings = totalBookings;
            ViewBag.TotalRoomBookings = totalRoomBookings;
            ViewBag.TotalRevenue = formattedNumber;
            return View();
        }
        public ActionResult Rooms()
        {
            return View();
        }
        public ActionResult RoomType()
        {
            return View();
        }
        public ActionResult Guest()
        {
            return View();
        }
        public ActionResult Staff()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Invoice()
        {
            return View();
        }
        public ActionResult RegistrationForm()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public JsonResult GetMonthlyEarning()
        {
            var monthlyEarning = db.HoaDons
                .GroupBy(h => new { Year = h.NgayLapHoaDon.Year, Month = h.NgayLapHoaDon.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalEarning = g.Sum(h => h.TienPhong + (h.TienDichVu ?? 0))
                })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToList();
            return Json(monthlyEarning, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetYearlyEarning()
        {
            var yearlyEarning = db.HoaDons
                .GroupBy(h => h.NgayLapHoaDon.Year)
                .Select(g => new
                {
                    Year = g.Key,
                    TotalEarning = g.Sum(h => h.TienPhong + (h.TienDichVu ?? 0))
                })
                .OrderBy(g => g.Year)
                .ToList();
            return Json(yearlyEarning, JsonRequestBehavior.AllowGet);
        }
    }
}