using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class NhanVienGiaoDichBLL
    {
        public static List<DichVu> getAllDichVu()
        {
            return NhanVienGiaoDichDAL.getAllDichVu();
        }

        public static List<PTVC> getAllPTVC()
        {
            return NhanVienGiaoDichDAL.getAllPTVC();
        }

        public static List<ChiDanKhongPhatDuoc> getAllCDKPD()
        {
            return NhanVienGiaoDichDAL.getAllCDKPD();
        }

        public static List<DichVuGTGT> getAllDVGTGT()
        {
            return NhanVienGiaoDichDAL.getAllDVGTGT();
        }

        public static List<KhachHang> getAllKhachHang()
        {
            return NhanVienGiaoDichDAL.getAllKhachHang();
        }

        public static List<Loai> getAllLoai()
        {
            return NhanVienGiaoDichDAL.getAllLoai();
        }

        public static List<BangGia> getAllBangGia()
        {
            return NhanVienGiaoDichDAL.getAllBangGia();
        }

        public static List<HangGui> getAllHangGui(int SHPhieuGui)
        {
            return NhanVienGiaoDichDAL.getAllHangGui(SHPhieuGui);
        }

        public static bool insertHangGui(int SHPhieuGui, HangGui hangGui)
        {
            return NhanVienGiaoDichDAL.insertHangGui(SHPhieuGui, hangGui);
        }

        public static bool removeAllHangGui(int SHPhieuGui)
        {
            return NhanVienGiaoDichDAL.removeAllHangGui(SHPhieuGui);
        }

        public static bool updateHangGui(int SHPhieuGui, List<HangGui> dsHangGui)
        {
            removeAllHangGui(SHPhieuGui);
            foreach (HangGui hg in dsHangGui)
            {
                insertHangGui(SHPhieuGui, hg);
            }
            return true;
        }

        public static bool lapPhieuGui(PhieuGui phieuGui, List<Loai> loai, List<HangGui> hangGui)
        {
            return NhanVienGiaoDichDAL.lapPhieuGui(phieuGui, loai, hangGui);
        }

        public static bool suaPhieuGui(PhieuGui phieuGui, List<Loai> loai, List<HangGui> hangGui)
        {
            return NhanVienGiaoDichDAL.suaPhieuGui(phieuGui, loai, hangGui);
        }

        public static bool xoaPhieuGui(int SHPhieuGui)
        {
            return NhanVienGiaoDichDAL.xoaPhieuGui(SHPhieuGui);
        }

        public static List<PhieuGui> danhSachPhieuGui()
        {
            return NhanVienGiaoDichDAL.danhSachPhieuGui();
        }
    }
}
