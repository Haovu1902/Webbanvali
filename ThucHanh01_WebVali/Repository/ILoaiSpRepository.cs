using ThucHanh01_WebVali.Models;

namespace ThucHanh01_WebVali.Repository
{
    public interface ILoaiSpRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(string maloai);
        TLoaiSp Delete(string maloai);
        TLoaiSp GetLoaiSp(string MaLoai);
        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
