using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTL_WebBanSach05.Models;

namespace BTL_WebBanSach05.Areas.Admin.Controllers
{
    public class SachController : ApiController
    {
        WebBanSach9Entities db = new WebBanSach9Entities();
        // GET: api/Sach
        public Array Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SACH> sach = db.SACHes.ToList();
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            List<THELOAI> theloai = db.THELOAIs.ToList();
            List<NXB> nxb = db.NXBs.ToList();

            var list = (from sp in sach
                        join tg in tacgia on sp.MATACGIA equals tg.MATACGIA
                        join tl in theloai on sp.MATHELOAI equals tl.MATHELOAI
                        join n in nxb on sp.MANXB equals n.MANXB
                        select new
                        {
                            MaSanPham = sp.MASACH,
                            TenSanPham = sp.TENSACH,
                            TenAnh = sp.TENANH,
                            NGUOIDICH = sp.NGUOIDICH,
                            NGONNGU = sp.NGONNGU,
                            SOTRANG = sp.SOTRANG,
                            TRONGLUONG = sp.TRONGLUONG,
                            NAMXUATBAN = sp.NAMXUATBAN,
                            KICHTHUOC = sp.KICHTHUOC,
                            GIANHAP = sp.GIANHAP,
                            GIABAN = sp.GIABAN,
                            TenTacGia = tg.TENTACGIA,
                            TheLoai = tl.TENTHELOAI,
                            NXB = n.TENNXB
                        });

            return list.ToArray();
        }

        //6. Tim kiem san pham 
        [HttpGet]
        public Array Get(int masp, int maTG, int maNXB, int maTL)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SACH> sach = db.SACHes.ToList();
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            List<THELOAI> theloai = db.THELOAIs.ToList();
            List<NXB> nxb = db.NXBs.ToList();

            var list = (from sp in sach
                        join tg in tacgia on sp.MATACGIA equals tg.MATACGIA
                        join tl in theloai on sp.MATHELOAI equals tl.MATHELOAI
                        join n in nxb on sp.MANXB equals n.MANXB
                        where sp.MASACH == masp
                        where sp.MATACGIA == maTG
                        where sp.MANXB == maNXB
                        where sp.MATHELOAI == maTL

                        select new
                        {
                            MaSanPham = sp.MASACH,
                            TenSanPham = sp.TENSACH,
                            TenAnh = sp.TENANH,
                            NGUOIDICH = sp.NGUOIDICH,
                            NGONNGU = sp.NGONNGU,
                            SOTRANG = sp.SOTRANG,
                            TRONGLUONG = sp.TRONGLUONG,
                            NAMXUATBAN = sp.NAMXUATBAN,
                            KICHTHUOC = sp.KICHTHUOC,
                            GIANHAP = sp.GIANHAP,
                            GIABAN = sp.GIABAN,
                            TenTacGia = tg.TENTACGIA,
                            TheLoai = tl.TENTHELOAI,
                            NXB = n.TENNXB
                        });
            return list.ToArray();
        }
        [HttpGet]
        public Array Get(int masp)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SACH> sach = db.SACHes.ToList();
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            List<THELOAI> theloai = db.THELOAIs.ToList();
            List<NXB> nxb = db.NXBs.ToList();

            var list = (from sp in sach
                        join tg in tacgia on sp.MATACGIA equals tg.MATACGIA
                        join tl in theloai on sp.MATHELOAI equals tl.MATHELOAI
                        join n in nxb on sp.MANXB equals n.MANXB
                        where sp.MASACH == masp

                        select new
                        {
                            MaSanPham = sp.MASACH,
                            TenSanPham = sp.TENSACH,
                            TenAnh = sp.TENANH,
                            NGUOIDICH = sp.NGUOIDICH,
                            NGONNGU = sp.NGONNGU,
                            SOTRANG = sp.SOTRANG,
                            TRONGLUONG = sp.TRONGLUONG,
                            NAMXUATBAN = sp.NAMXUATBAN,
                            KICHTHUOC = sp.KICHTHUOC,
                            GIANHAP = sp.GIANHAP,
                            GIABAN = sp.GIABAN,
                            TenTacGia = tg.TENTACGIA,
                            TheLoai = tl.TENTHELOAI,
                            NXB = n.TENNXB
                        });

            return list.ToArray();
        }
        [HttpGet]
        public Array GetTG(int maTG)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SACH> sach = db.SACHes.ToList();
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            List<THELOAI> theloai = db.THELOAIs.ToList();
            List<NXB> nxb = db.NXBs.ToList();

            var list = (from sp in sach
                        join tg in tacgia on sp.MATACGIA equals tg.MATACGIA
                        join tl in theloai on sp.MATHELOAI equals tl.MATHELOAI
                        join n in nxb on sp.MANXB equals n.MANXB
                        where sp.MATACGIA == maTG

                        select new
                        {
                            MaSanPham = sp.MASACH,
                            TenSanPham = sp.TENSACH,
                            TenAnh = sp.TENANH,
                            NGUOIDICH = sp.NGUOIDICH,
                            NGONNGU = sp.NGONNGU,
                            SOTRANG = sp.SOTRANG,
                            TRONGLUONG = sp.TRONGLUONG,
                            NAMXUATBAN = sp.NAMXUATBAN,
                            KICHTHUOC = sp.KICHTHUOC,
                            GIANHAP = sp.GIANHAP,
                            GIABAN = sp.GIABAN,
                            TenTacGia = tg.TENTACGIA,
                            TheLoai = tl.TENTHELOAI,
                            NXB = n.TENNXB
                        });

            return list.ToArray();
        }
        [HttpGet]
        public Array GetTL(int maTL)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SACH> sach = db.SACHes.ToList();
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            List<THELOAI> theloai = db.THELOAIs.ToList();
            List<NXB> nxb = db.NXBs.ToList();

            var list = (from sp in sach
                        join tg in tacgia on sp.MATACGIA equals tg.MATACGIA
                        join tl in theloai on sp.MATHELOAI equals tl.MATHELOAI
                        join n in nxb on sp.MANXB equals n.MANXB
                        where sp.MATHELOAI == maTL

                        select new
                        {
                            MaSanPham = sp.MASACH,
                            TenSanPham = sp.TENSACH,
                            TenAnh = sp.TENANH,
                            NGUOIDICH = sp.NGUOIDICH,
                            NGONNGU = sp.NGONNGU,
                            SOTRANG = sp.SOTRANG,
                            TRONGLUONG = sp.TRONGLUONG,
                            NAMXUATBAN = sp.NAMXUATBAN,
                            KICHTHUOC = sp.KICHTHUOC,
                            GIANHAP = sp.GIANHAP,
                            GIABAN = sp.GIABAN,
                            TenTacGia = tg.TENTACGIA,
                            TheLoai = tl.TENTHELOAI,
                            NXB = n.TENNXB
                        });

            return list.ToArray();
        }
        [HttpGet]
        public Array GetNXB(int maNXB)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<SACH> sach = db.SACHes.ToList();
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            List<THELOAI> theloai = db.THELOAIs.ToList();
            List<NXB> nxb = db.NXBs.ToList();

            var list = (from sp in sach
                        join tg in tacgia on sp.MATACGIA equals tg.MATACGIA
                        join tl in theloai on sp.MATHELOAI equals tl.MATHELOAI
                        join n in nxb on sp.MANXB equals n.MANXB
                        where sp.MANXB == maNXB

                        select new
                        {
                            MaSanPham = sp.MASACH,
                            TenSanPham = sp.TENSACH,
                            TenAnh = sp.TENANH,
                            NGUOIDICH = sp.NGUOIDICH,
                            NGONNGU = sp.NGONNGU,
                            SOTRANG = sp.SOTRANG,
                            TRONGLUONG = sp.TRONGLUONG,
                            NAMXUATBAN = sp.NAMXUATBAN,
                            KICHTHUOC = sp.KICHTHUOC,
                            GIANHAP = sp.GIANHAP,
                            GIABAN = sp.GIABAN,
                            TenTacGia = tg.TENTACGIA,
                            TheLoai = tl.TENTHELOAI,
                            NXB = n.TENNXB
                        });

            return list.ToArray();
        }


        //3. them moi 1 san pham
        [HttpPost]
        public bool InsertSanPham(string tenSP, string tenanh, string nguoidich, string ngonngu,
            int sotrang, int trongluong, string namXB, string kichthuoc, int maTL, int maTG,
            int maNXB, int gianhap, int giaban)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                WebBanSach9Entities dbSanPham = new WebBanSach9Entities();
                SACH sanpham = new SACH();
                sanpham.TENSACH = tenSP;
                sanpham.TENANH = tenanh;
                sanpham.NGUOIDICH = nguoidich;
                sanpham.NGONNGU = ngonngu;
                sanpham.SOTRANG = sotrang;
                sanpham.TRONGLUONG = trongluong;
                sanpham.NAMXUATBAN = namXB;
                sanpham.KICHTHUOC = kichthuoc;
                sanpham.MATHELOAI = maTL;
                sanpham.MATACGIA = maTG;
                sanpham.MANXB = maNXB;
                sanpham.GIANHAP = gianhap;
                sanpham.GIABAN = giaban;

                dbSanPham.SACHes.Add(sanpham);
                dbSanPham.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //4. sua thong tin san pham
        [HttpPut]
        public bool UpdateSP(int maSP, string tenSP, string tenanh, string nguoidich, string ngonngu,
            int sotrang, int trongluong, string namXB, string kichthuoc, int maTL, int maTG,
            int maNXB, int gianhap, int giaban)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                WebBanSach9Entities dbsanpham = new WebBanSach9Entities();
                SACH sanpham = dbsanpham.SACHes.FirstOrDefault(x => x.MASACH == maSP);
                if (sanpham == null)
                {
                    return false;
                }
                sanpham.MASACH = maSP;
                sanpham.TENSACH = tenSP;
                sanpham.TENANH = tenanh;
                sanpham.NGUOIDICH = nguoidich;
                sanpham.NGONNGU = ngonngu;
                sanpham.SOTRANG = sotrang;
                sanpham.TRONGLUONG = trongluong;
                sanpham.NAMXUATBAN = namXB;
                sanpham.KICHTHUOC = kichthuoc;
                sanpham.MATHELOAI = maTL;
                sanpham.MATACGIA = maTG;
                sanpham.MANXB = maNXB;
                sanpham.GIANHAP = gianhap;
                sanpham.GIABAN = giaban;

                dbsanpham.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
        //5. xoa san pham
        [HttpDelete]
        public bool DeleteSP(int id)
        {
            try
            {
                WebBanSach9Entities dbsanpham = new WebBanSach9Entities();
                SACH sanpham = dbsanpham.SACHes.FirstOrDefault(x => x.MASACH == id);
                if (sanpham == null)
                {
                    return false;
                }

                dbsanpham.SACHes.Remove(sanpham);
                dbsanpham.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
