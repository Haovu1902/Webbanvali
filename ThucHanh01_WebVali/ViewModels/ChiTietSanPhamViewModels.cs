using ThucHanh01_WebVali.Models;
namespace ThucHanh01_WebVali.ViewModels
{
    public class ChiTietSanPhamViewModels
    {
        TDanhMucSp? sanPham { get; set; }
        List<TAnhSp?> anhSanPham { get; set; }

        public ChiTietSanPhamViewModels(TDanhMucSp? sanPham, List<TAnhSp?> anhSanPham)
        {
            this.sanPham = sanPham;
            this.anhSanPham = anhSanPham;
        }
    }
}
