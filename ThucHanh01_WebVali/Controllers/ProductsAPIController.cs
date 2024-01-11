using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucHanh01_WebVali.Models;
using ThucHanh01_WebVali.Models.ProductsModel;

namespace ThucHanh01_WebVali.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var sanPham = (from p in db.TDanhMucSps
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat
                           }).ToList();
            return sanPham;
            //return db.TDanhMucSps.OrderBy(x=>x.TenSp).ToList();
        }

        [HttpGet("{maLoai}")]
        public IEnumerable<Product> GetProductsByCategory(string maLoai)
        {
            List<Product> products = new List<Product>();
            var sanPhams = db.TDanhMucSps.Where(x=>x.MaLoai==maLoai).ToList();
            foreach(var s in sanPhams)
            {
                products.Add(new Product { MaSp = s.MaSp, TenSp = s.TenSp, MaLoai = s.MaLoai, AnhDaiDien = s.AnhDaiDien, GiaNhoNhat = s.GiaNhoNhat });
            }
            return products;
            //return db.TDanhMucSps.Where(x=>x.MaLoai==maLoai).OrderBy(x=>x.TenSp).ToList();
        }
    }
}
