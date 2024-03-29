﻿using Microsoft.AspNetCore.Mvc;
using ThucHanh01_WebVali.Repository;

namespace ThucHanh01_WebVali.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSpRepository;
        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSpRepository = loaiSpRepository;
        }

        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSpRepository.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaisp);
        }
    }
}
