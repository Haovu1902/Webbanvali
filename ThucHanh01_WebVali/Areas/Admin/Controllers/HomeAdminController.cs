using ThucHanh01_WebVali.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Lab2.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("danhsachsanpham")]
        public IActionResult DanhSachSanPham(int? page)
        {
            int pageSize = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }

        [Route("SuaSanPham")]
        [HttpGet]

        public IActionResult SuaSanPham(string maSanPham)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus, "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes, "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia, "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps, "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts, "MaDt", "TenLoai");

            var sanPham = db.TDanhMucSps.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }

        [Route("ThemSanPham")]
        [HttpGet]

        public IActionResult ThemSanPham()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus, "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes, "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia, "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps, "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts, "MaDt", "TenLoai");

            return View();
        }

        [Route("ThemSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPham(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(sanPham).State = EntityState.Modified;
                db.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhSachSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }

        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string masp)
        {
            TempData["Message"] = "";
            var listChiTiet = db.TChiTietSanPhams.Where(x => x.MaSp == masp);
            foreach (var item in listChiTiet)
            {
                if (db.TChiTietHdbs.Where(x => x.MaChiTietSp == item.MaChiTietSp) != null)
                {
                    TempData["Message"] = "Không xoá được sản phẩm này";
                    return RedirectToAction("DanhSachSanPham");
                }
            }
            var listAnh = db.TAnhSps.Where(x => x.MaSp == masp);
            if (listAnh != null)
            {
                db.RemoveRange(listAnh);
            }
            if (listChiTiet != null)
            {
                db.RemoveRange(listChiTiet);
            }
            db.Remove(db.TDanhMucSps.Find(masp));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xoá";
            return RedirectToAction("DanhSachSanPham");
        }
        
    }
}