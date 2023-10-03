using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class PhieuGui
    {
        public int SH {get; set;}
        public DateTime NgayChapNhan { get; set; }
        public int KhoiLuongCanThuc { get; set; }
        public int KhoiLuongQuyDoi { get; set;}
        public string TinhTrang { get; set; }
        public BuuCuc buuCucGui { get; set; }
        public BuuCuc buuCucNhan { get; set; }
        public KhachHang khachHangGui { get; set; }
        public KhachHang khachHangNhan { get; set; }
        public DichVu dichVu { get; set; }
        public PTVC ptvc { get; set; }
        public ChiDanKhongPhatDuoc cdkpd { get; set; }
        public List<Loai> loai { get; set; }
        public List<HangGui> hangGui { get; set; }
        public List<DichVuGTGT> gtgt { get; set; }
        public PhieuGui() { }

        public PhieuGui(int SH, int KhoiLuongCanThuc, int KhoiLuongQuyDoi, DateTime NgayChapNhan, string TinhTrang, BuuCuc buuCucGui, BuuCuc buuCucNhan, KhachHang khachHangGui, KhachHang khachHangNhan, DichVu dichVu, PTVC ptvc, ChiDanKhongPhatDuoc cdkpd, List<Loai> loai, List<HangGui> hangGui, List<DichVuGTGT> gtgt)
        {
            this.SH = SH;
            this.KhoiLuongCanThuc = KhoiLuongCanThuc;
            this.KhoiLuongQuyDoi = KhoiLuongQuyDoi;
            this.NgayChapNhan = NgayChapNhan;
            this.TinhTrang = TinhTrang;
            this.buuCucGui = buuCucGui;
            this.buuCucNhan = buuCucNhan;
            this.khachHangGui = khachHangGui;
            this.khachHangNhan = khachHangNhan;
            this.dichVu = dichVu;
            this.ptvc = ptvc;
            this.cdkpd = cdkpd;
            this.loai = loai;
            this.hangGui = hangGui;
            this.gtgt = gtgt;
        }

        public static List<String> getAllProperties()
        {
            return new List<String> { "Số Hiệu", "Ngày Chấp Nhận", "Khối Lượng Cân Thực", "Khối Lượng Quy Đổi", "Tình Trạng"};
        }
    }

}