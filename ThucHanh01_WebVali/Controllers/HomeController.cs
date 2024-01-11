using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Diagnostics;
using ThucHanh01_WebVali.Models;
using ThucHanh01_WebVali.ViewModels;
using X.PagedList;
using ThucHanh01_WebVali.Models.Authentication;

namespace ThucHanh01_WebVali.Controllers
{
    public class HomeController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authentication]
        public IActionResult Index(int? page)
        {
            int pageNumber = page == null || page < 1 ? 1 : page.Value;
            int pageSize = 8;
            var listSanPham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listSanPham, pageNumber, pageSize);
            return View(lst);
        }

        public IActionResult ChiTietSanPham(string maSp)
        {

            var sanpham = db.TDanhMucSps.SingleOrDefault(x=>x.MaSp== maSp);
            var anhSanPham = db.TAnhSps.Where(x=>x.MaSp==maSp).ToList();
            ViewBag.anhSanPham = anhSanPham;
            //var sanpham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            //var anh = db.TAnhSps.Where(x => x.MaSp == maSp).AsNoTracking().ToList();
            //var sp = new ChiTietSanPhamViewModels(sanpham, anh);
            if (sanpham == null)
            {
                return RedirectToAction("Index");
            } else
            {
                return View(sanpham);
            }
        }

        //home/sanphamtheoloai?maloai=vali (tui, balo...)
        public IActionResult SanPhamTheoLoai(String MaLoai, int? page)
        {
            //List<TDanhMucSp> lstDanhMucSp = db.TDanhMucSps.Where(x=>x.MaLoai==MaLoai).ToList();
            int pageNumber = page == null || page < 1 ? 1 : page.Value;
            int pageSize = 8;
            var listSanPham = db.TDanhMucSps.AsNoTracking().Where(x => x.MaLoai == MaLoai).ToList();
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listSanPham, pageNumber, pageSize);
            ViewBag.MaLoai = MaLoai;
            return View(lst);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}