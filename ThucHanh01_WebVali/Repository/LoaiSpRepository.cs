using ThucHanh01_WebVali.Models;

namespace ThucHanh01_WebVali.Repository
{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly QlbanVaLiContext _context;
        public LoaiSpRepository(QlbanVaLiContext context)
        {
            _context = context;
        }
        public TLoaiSp Add(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

        public TLoaiSp Delete(string maloai)
        {
            throw new NotImplementedException();
        }

        public TLoaiSp GetLoaiSp(string MaLoai)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp Update(string maloai)
        {
            throw new NotImplementedException();
        }
    }
}
